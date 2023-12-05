using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class EsqueceuSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public EsqueceuSenhaController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult EsqueceuSenhaIndex()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AlterarSenha(string nomeUsuario, string respostaSeguranca, string novaSenha)
        {
            Usuario usuario = new Usuario();
            usuario.nomeUsuario = nomeUsuario;
            usuario.respostaSeguranca = respostaSeguranca;
            usuario.senha = novaSenha;
            usuario = _usuarioRepositorio.ValidarResposta(usuario);
            var respostaSegura = VerificarRespostaSeguranca(usuario, respostaSeguranca);

            if (usuario != null && respostaSegura == true)
            {
                usuario.senha = novaSenha;


                _usuarioRepositorio.AtualizarSenha(usuario);

                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("EsqueceuSenhaIndex");
            }
        }

        private bool VerificarRespostaSeguranca(Usuario usuario, string respostaSeguranca)
        {

            if (usuario != null && !string.IsNullOrEmpty(usuario.respostaSeguranca))
            {

                return string.Equals(usuario.respostaSeguranca, respostaSeguranca, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}
