using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Eventos_PuntoNet.Components.Models
{
    public class Sensor
    {
        [Key]
        public int Id_Sensor { get; set; }
        public int Distancia { get; set; }

        public ICollection<Marca>? Marcas { get; set; }
    }
}
