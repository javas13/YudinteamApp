using Microsoft.AspNetCore.Mvc;

namespace YoudinTeamApp.Controllers
{
    public class Site_Pod_KlychController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
