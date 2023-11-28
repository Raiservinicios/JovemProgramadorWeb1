using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class ParticipacaoController : Controller
    {
        private readonly IParticipacaoRepositorio _participacaoRepositorio;

        public ParticipacaoController(IParticipacaoRepositorio participacaoRepositorio)
        {
            _participacaoRepositorio = participacaoRepositorio;
        }

        public IActionResult ParticipacaoIndex()
        {
            var participacao = _participacaoRepositorio.ObterParticipacaoEventos();
            return View(participacao);
        }
    }
}


