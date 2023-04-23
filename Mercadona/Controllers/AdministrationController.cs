using Microsoft.AspNetCore.Mvc;

namespace Mercadona.Controllers
{
    public class AdministrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
