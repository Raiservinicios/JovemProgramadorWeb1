using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventoRepositorio _eventoRepositorio;

        public EventosController(IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }

        public IActionResult EventosIndex()
        {
            var eventos = _eventoRepositorio.ObterTodosEventos();
            return View(eventos);
        }
    }
}
