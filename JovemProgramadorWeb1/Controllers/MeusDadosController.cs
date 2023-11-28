using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class MeusDadosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public MeusDadosController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult MeusDadosIndex()
        {
            int codigoUsuarioLogado = ObterCodigoUsuarioLogado();

            Socio socio = _usuarioRepositorio.ObterSocioPorCodigoUsuario(codigoUsuarioLogado);

            return View(socio);
        }

        private int ObterCodigoUsuarioLogado()
        {
            return 1; // Apenas para fins de exemplo
        }
    }
}
