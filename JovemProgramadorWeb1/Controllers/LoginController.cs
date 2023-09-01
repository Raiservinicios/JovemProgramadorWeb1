using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
	private readonly IUsuarioRepositorio _usuarioRepositorio;

    public LoginController(IUsuarioRepositorio usuarioRepositorio)
    {
		_usuarioRepositorio = usuarioRepositorio;
    }
    public IActionResult Index()
	{
		return View();
	}

    public IActionResult BuscaLogin(Usuario usuario)
    {
        try
        {
            var acesso = _usuarioRepositorio.ValidarUsuario(usuario);

            if (acesso != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MsgErro"] = "Usuário ou senha incorretos! Tente novamente...";
                return RedirectToAction("Index"); // Redireciona de volta para a página de login
            }
        }
        catch (Exception)
        {
            TempData["MsgErro"] = "Erro ao validar o login.";
            return RedirectToAction("Index"); // Redireciona de volta para a página de login
        }
    }
}
