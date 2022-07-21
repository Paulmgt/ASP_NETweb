using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TpCRUDMVCScolariteSuivi.Models;

namespace TpCRUDMVCScolariteSuivi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ScolariteDbEntities _context;

        public HomeController(ILogger<HomeController> logger, ScolariteDbEntities context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Modules != null ?
                        View(await _context.Modules.ToListAsync()) :
                        Problem("Entity set 'ScolariteDbEntities.Modules'  is null.");
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