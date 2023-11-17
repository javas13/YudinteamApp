using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YoudinTeamApp.Data;
using YoudinTeamApp.Models;

namespace YoudinTeamApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Service> ServiceList = _db.Services.Where(x=> x.Display_Order != 0).OrderBy(x => x.Display_Order).ToList();
            return View(ServiceList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}