using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class MeusDadosController : Controller
    {
        public IActionResult MeusDadosIndex()
        {
            return View();
        }
    }
}
