using System.ComponentModel.DataAnnotations;

namespace CarreraenVivo.Models
{
    public class Sensor
    {
        [Key]
        public int Id_Sensor { get; set; }
        public int Distancia { get; set; }

    }
}
