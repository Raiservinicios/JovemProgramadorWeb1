using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult EventosIndex()
        {
            return View();
        }
    }
}
