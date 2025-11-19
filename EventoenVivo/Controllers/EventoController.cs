using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventoenVivo.Controllers
{
    public class EventoController : Controller
    {
        // GET: /Evento/EnVivo?Titulo=...&Descripcion=...&Fecha=...&ImagenUrl=...
        public IActionResult EnVivo(string Titulo, string Descripcion, string Fecha, string ImagenUrl)
        {
            // Validamos que haya un título (mínimo para saber que hay datos)
            if (string.IsNullOrEmpty(Titulo))
            {
                return RedirectToAction("Index"); // Redirige al inicio si no hay datos
            }

            // Creamos un modelo temporal para la vista
            var evento = new Evento
            {
                Titulo = Titulo,
                Descripcion = Descripcion,
                Fecha = Fecha,
                ImagenUrl = ImagenUrl
            };

            return View(evento);
        }
    }

    // Modelo simple para la vista
    public class Evento
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public string ImagenUrl { get; set; }
    }
}
