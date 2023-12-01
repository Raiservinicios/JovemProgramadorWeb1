using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class EsqueceuSenhaController : Controller
    {
        public IActionResult EsqueceuSenhaIndex()
        {
            return View();
        }
    }
}
