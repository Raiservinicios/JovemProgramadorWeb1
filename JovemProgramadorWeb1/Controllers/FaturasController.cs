using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class FaturasController : Controller
    {
        public IActionResult FaturasIndex()
        {
            return View();
        }
    }
}
