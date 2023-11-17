using Microsoft.AspNetCore.Mvc;
using YoudinTeamApp.Models;
using YoudinTeamApp.Data;

namespace YoudinTeamApp.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ServicesController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Service> ServiceList = _db.Services.ToList();
            return View(ServiceList);
        }
    }
}
