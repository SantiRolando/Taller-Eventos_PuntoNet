using Eventos_PuntoNet.Components.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos_PuntoNet.Components.Models
{
    public class Leaderboard
    {
        [Key]
        public int Id { get; set; }

        public int Dorsal_Atleta { get; set; }

        [ForeignKey("Sensor")]
        public int Id_Sensor { get; set; }

        public DateTime Tiempo { get; set; }

        public Sensor? Sensor { get; set; }
    }
}

