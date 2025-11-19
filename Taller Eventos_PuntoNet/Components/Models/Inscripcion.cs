using Eventos_PuntoNet.Components.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Eventos_PuntoNet.Components.Models
{

    public class Inscripcion
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public string Ci_Usuario { get; set; }

        [ForeignKey("Evento")]
        public int Id_Evento { get; set; }

        [Required]
        public int Id_Chip { get; set; }

        [Required]
        public int Dorsal_Atleta { get; set; }

        public Usuario? Usuario { get; set; }
        public Evento? Evento { get; set; }
    }

}