using EventoenVivo.Controllers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventos_PuntoNet.Components.Models
{
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = "La cédula es obligatoria.")]
        public string Ci { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Email no válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string TipoUsuario { get; set; } = string.Empty;
    }
    /*
    public class Participante : Usuario
    {
        public ICollection<Inscripcion>? Inscripciones { get; set; }
    }
    */
    public class Admin : Usuario
    {
        public void CrearEvento(Evento evento)
        {
            // Implementación si hace falta.
        }
    }
}
