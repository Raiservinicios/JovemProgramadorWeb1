using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class FaturasController : Controller
    {
        private readonly IFaturaRepositorio _faturaRepositorio;

        public FaturasController(IFaturaRepositorio faturaRepositorio)
        {
            _faturaRepositorio = faturaRepositorio;
        }
        public IActionResult FaturasIndex()
        {
            var listaDeFaturas = _faturaRepositorio.ObterTodasFaturas();
            return View(listaDeFaturas);
        }
    }
}
