using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventoenVivo.Controllers
{
    public class EventoController : Controller
    {
        // GET: /Evento/EnVivo?Titulo=...&Descripcion=...&Fecha=...&ImagenUrl=...
        public IActionResult EnVivo(int id, string Titulo, string Descripcion, string Fecha, string ImagenUrl)
        {
            // Validamos que haya un título (mínimo para saber que hay datos)
            if (string.IsNullOrEmpty(Titulo))
            {
                return RedirectToAction("Index"); // Redirige al inicio si no hay datos
            }

            // Creamos un modelo temporal para la vista
            var evento = new Evento
            {
                Id = id,
                Titulo = Titulo,
                Descripcion = Descripcion,
                Fecha = Fecha,
                ImagenUrl = ImagenUrl
            };

            return View(evento);
        }


    [HttpGet("Evento/Top10/{id}")]
        public IActionResult Top10(int id, string nombre)
        {
            var model = new Top10ViewModel
            {
                Id = id,
                Nombre = nombre
            };

            return View(model);
        }

    }



    // Modelo simple para la vista
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public string ImagenUrl { get; set; }
    }

    public class Top10ViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

}
