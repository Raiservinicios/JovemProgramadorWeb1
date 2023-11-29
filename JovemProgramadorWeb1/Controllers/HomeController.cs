using JovemProgramadorWeb1.Data.Repositorio;
using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;


namespace JovemProgramadorWeb1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUsuarioRepositorio usuarioRepositorio)
        {
            _logger = logger;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index(Usuario usuario, Socio socio)
        {

            return View(usuario);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
         
		public ActionResult UsuarioEncontrado()
		{
			return View("Index");
		}
        public ActionResult UsuarioNaoEncontrado()
        {
            return View("IndexErro");
        }

        

    }
}
