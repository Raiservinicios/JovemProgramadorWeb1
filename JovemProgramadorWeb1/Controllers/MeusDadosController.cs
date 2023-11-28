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
        public IActionResult MeusDadosIndex(Usuario usuario, Socio socio)
        {
            //socio = _usuarioRepositorio.BuscarDadosSocio(usuario);
            return View();
        }


    }
}
