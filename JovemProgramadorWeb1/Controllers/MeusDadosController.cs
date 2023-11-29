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

        public IActionResult MeusDadosIndex(int codigo)
        {
            int codigoUsuarioLogado = codigo;

            Socio socio = _usuarioRepositorio.ObterSocioPorCodigoUsuario(codigoUsuarioLogado);

            return View(socio);
        }

    }
}
