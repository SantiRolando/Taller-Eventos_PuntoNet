using Eventos_PuntoNet.Components.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tarea_SingalR.Hubs
{
    public class EventoHub : Hub
    {
        private readonly SeguimientoService _seguimientoService;

        public EventoHub(SeguimientoService seguimientoService)
        {
            _seguimientoService = seguimientoService;
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Cliente conectado: {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"Cliente desconectado: {Context.ConnectionId} - {exception?.Message}");
            await base.OnDisconnectedAsync(exception);
        }

        // Método llamado desde el MVC o cliente para iniciar seguimiento de un dorsal
        public async Task IniciarSeguimiento(int dorsal)
        {
            // Agregar al grupo y registrar en el servicio
            await _seguimientoService.IniciarSeguimiento(dorsal, Context.ConnectionId);
        }
    }

    // Servicio externo para manejo de seguimiento
    public class SeguimientoService
    {
        private readonly IHubContext<EventoHub> _hubContext;
        private readonly Dictionary<int, int> corredores = new(); // Dorsal -> Dummy
        private readonly Timer _timer;

        public SeguimientoService(IHubContext<EventoHub> hubContext)
        {
            _hubContext = hubContext;

            // Timer global cada 1 segundo
            _timer = new Timer(async _ =>
            {
                foreach (var dorsal in corredores.Keys)
                {
                    var corredor = new
                    {
                        dorsal_Atleta = dorsal,
                        id_Sensor = new Random().Next(1, 5),
                        tiempo = DateTime.Now
                    };

                    await _hubContext.Clients.Group(dorsal.ToString())
                                             .SendAsync("RecibirCorredor", corredor);
                }
            }, null, 0, 1000);
        }

        public async Task IniciarSeguimiento(int dorsal, string connectionId)
        {
            if (!corredores.ContainsKey(dorsal))
                corredores[dorsal] = dorsal;

            await _hubContext.Groups.AddToGroupAsync(connectionId, dorsal.ToString());
        }
    }
}
