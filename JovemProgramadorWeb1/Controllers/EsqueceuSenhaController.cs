using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class EsqueceuSenhaController : Controller
    {
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
=======
>>>>>>> Vinicios_Branch
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public EsqueceuSenhaController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
<<<<<<< HEAD
        

        [HttpGet]
>>>>>>> Stashed changes
=======


        [HttpGet]
>>>>>>> Vinicios_Branch
        public IActionResult EsqueceuSenhaIndex()
        {
            return View();
        }
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
=======
>>>>>>> Vinicios_Branch

        [HttpPost]

        [HttpPost]
        public IActionResult AlterarSenha(string nomeUsuario, string respostaSeguranca, string novaSenha)
        {
            Usuario usuario = new Usuario
            {
                nomeUsuario = nomeUsuario,
                respostaSeguranca = respostaSeguranca,
                senha = novaSenha
            };

            var usuarioValidado = _usuarioRepositorio.ValidarResposta(usuario);

            if (usuarioValidado != null && VerificarRespostaSeguranca(usuarioValidado, respostaSeguranca))
            {
                usuarioValidado.senha = novaSenha;
                _usuarioRepositorio.AtualizarSenha(usuarioValidado);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public IActionResult Index()
        {

            return View();
        }

        private bool VerificarRespostaSeguranca(Usuario usuario, string respostaSeguranca)
        {

            if (usuario != null && !string.IsNullOrEmpty(usuario.respostaSeguranca))
            {

                return string.Equals(usuario.respostaSeguranca, respostaSeguranca, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
<<<<<<< HEAD
>>>>>>> Stashed changes
=======
>>>>>>> Vinicios_Branch
    }
}