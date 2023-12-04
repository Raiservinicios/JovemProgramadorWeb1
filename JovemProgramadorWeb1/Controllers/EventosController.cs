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

        public IActionResult EventosIndex(int codigo)
        {
            var eventos = _eventoRepositorio.ObterTodosEventos();
            ViewBag.codigoSocio = codigo;
            return View(eventos);
        }
    }
}
