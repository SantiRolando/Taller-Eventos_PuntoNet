using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos_PuntoNet.Components.Models
{
    public class Usuario
    {
        [Key]
        public int Ci { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class Participante : Usuario
    {
        public ICollection<Inscripcion>? Inscripciones { get; set; }

    }

    public class Admin : Usuario
    {
        public void CrearEvento(Evento evento) { }

    }
}
