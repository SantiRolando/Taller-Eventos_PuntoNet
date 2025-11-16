using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos_PuntoNet.Components.Models
{
    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Sensor { get; set; }


        public int Distancia { get; set; } // En Km

        // Relación con Evento
        [ForeignKey("Evento")]
        public int EventoId { get; set; }
        public Evento? Evento { get; set; }

        public ICollection<Marca>? Marcas { get; set; }
    }
}
