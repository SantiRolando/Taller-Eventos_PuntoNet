using CarreraenVivo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CarreraenVivoi.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult EnVivo(int id)
        {
            return View();
        }
    }
}

