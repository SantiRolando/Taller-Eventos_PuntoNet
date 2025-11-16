using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos_PuntoNet.Components.Models

{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public int Km { get; set; }
        public int Cantidad_Inscritos { get; set; }
        public int Cantidad_Kits { get; set; }

        public byte[]? Imagen { get; set; }

        public ICollection<Inscripcion>? Inscripciones { get; set; }
        public ICollection<Sensor>? Sensores { get; set; }
        public ICollection<Leaderboard>? Leaderboard { get; set; }
    }
}
