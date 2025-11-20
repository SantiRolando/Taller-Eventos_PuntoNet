using Eventos_PuntoNet.Components.Data;
using Eventos_PuntoNet.Components.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Eventos_PuntoNet.Components.Hubs
{
    public class EventoHub : Hub
    {
        private readonly SeguimientoService _seguimientoService;

        public EventoHub(SeguimientoService seguimientoService)
        {
            _seguimientoService = seguimientoService;
        }

        // === NUEVO: Top 10 ===
        public async Task ObtenerTop10(int carreraId)
        {
            await _seguimientoService.EnviarTop10(carreraId, Context.ConnectionId);
        }

        // === YA EXISTENTE: seguimiento por dorsal ===
        public async Task IniciarSeguimiento(int carreraId, int dorsal)
        {
            await _seguimientoService.IniciarSeguimiento(carreraId, dorsal, Context.ConnectionId);
        }
    }

    public class SeguimientoService
    {
        private readonly IHubContext<EventoHub> _hubContext;
        private readonly AppDbContext _context;

        private readonly Dictionary<string, CorredorSimulado> corredores = new();
        private readonly Timer _timer;

        public SeguimientoService(IHubContext<EventoHub> hubContext, AppDbContext context)
        {
            _hubContext = hubContext;
            _context = context;

            // Timer cada 10 segundos (tu código original)
            _timer = new Timer(async _ => await Tick(), null, 0, 10000);
        }

        // ==== NUEVO: Enviar Top 10 corredores ====
        public async Task EnviarTop10(int carreraId, string connectionId)
        {
            // 1. Obtener todos los tiempos de la carrera
            var tiempos = await _context.Leaderboards
                .Include(l => l.Sensor)
                .Where(l => l.Sensor.EventoId == carreraId)
                .ToListAsync();

            if (!tiempos.Any())
            {
                await _hubContext.Clients.Client(connectionId)
                    .SendAsync("RecibirTop10", new List<object>());
                return;
            }

            // 2. Agrupar por dorsal y quedarnos con el tiempo MÁS RECIENTE
            var top10 = tiempos
                .GroupBy(l => l.Dorsal_Atleta)
                .Select(g => g.OrderByDescending(x => x.Tiempo).First())
                .OrderBy(x => x.Tiempo)
                .Take(10)
                .ToList();

            // 3. Enviar uno por uno con 2 segundos de retraso
            foreach (var x in top10)
            {
                var corredor = new
                {
                    dorsal = x.Dorsal_Atleta,
                    nombre = "Nombre del corredor", // luego reemplazar con el real
                    sensor = "Finalizó",
                    tiempo = x.Tiempo
                };

                await _hubContext.Clients.Client(connectionId)
                    .SendAsync("RecibirTop10", new List<object> { corredor });

                await Task.Delay(2000); // esperar 2 segundos antes de enviar el siguiente
            }
        }

        // ==== ORIGINAL: Tick que envía progreso del corredor ====
        private async Task Tick()
        {
            foreach (var entry in corredores.Values)
            {
                if (entry.Terminado) continue;

                // Pasar al siguiente sensor
                entry.SensorIndex++;

                if (entry.SensorIndex >= entry.Sensores.Count)
                {
                    entry.Terminado = true;
                }

                var sensorActual =
                    entry.SensorIndex < entry.Sensores.Count
                    ? entry.Sensores[entry.SensorIndex]
                    : null;

                var data = new
                {
                    dorsal_Atleta = entry.Dorsal,
                    id_Sensor = sensorActual?.Id_Sensor ?? -1,
                    tiempo = DateTime.Now,
                    terminado = entry.Terminado
                };

                await _hubContext.Clients.Group(entry.Grupo).SendAsync("RecibirCorredor", data);
            }
        }

        // ==== ORIGINAL: seguimiento por dorsal ====
        public async Task IniciarSeguimiento(int carreraId, int dorsal, string connectionId)
        {
            string key = $"{carreraId}_{dorsal}";

            if (!corredores.ContainsKey(key))
            {
                var leader = await _context.Leaderboards
                    .Include(l => l.Sensor)
                    .Where(l => l.Dorsal_Atleta == dorsal && l.Sensor.EventoId == carreraId)
                    .FirstOrDefaultAsync();

                if (leader == null)
                {
                    await _hubContext.Clients.Client(connectionId)
                        .SendAsync("RecibirError", "Dorsal no encontrado en esta carrera.");
                    return;
                }

                var sensores = await _context.Sensores
                    .Where(s => s.EventoId == carreraId)
                    .OrderBy(s => s.Distancia)
                    .ToListAsync();

                var entry = new CorredorSimulado
                {
                    Dorsal = dorsal,
                    Sensores = sensores,
                    SensorIndex = -1,
                    Terminado = false,
                    Grupo = dorsal.ToString()
                };

                corredores[key] = entry;
            }

            // Agregar al grupo para recibir actualizaciones
            await _hubContext.Groups.AddToGroupAsync(connectionId, dorsal.ToString());
        }
    }

    // === Clase auxiliar ===
    public class CorredorSimulado
    {
        public int Dorsal { get; set; }
        public List<Sensor> Sensores { get; set; } = new();
        public int SensorIndex { get; set; }
        public bool Terminado { get; set; }
        public string Grupo { get; set; } = string.Empty;
    }
}
