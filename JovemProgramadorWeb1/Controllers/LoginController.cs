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
            usuario = _usuarioRepositorio.ValidarUsuario(usuario);
            if (usuario != null)
            {
                return RedirectToAction("Index", "Home", usuario);
            }
            else
            {
                TempData["MsgErro"] = "Usuário ou senha incorretos! Tente novamente...";
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            TempData["MsgErro"] = "Erro ao validar o login. Detalhes: " + ex.Message;
            return RedirectToAction("Index");
        }
    }
}
