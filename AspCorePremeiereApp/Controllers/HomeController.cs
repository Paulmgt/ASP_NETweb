using AspCorePremeiereApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspCorePremeiereApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // todo 
            // 
            return View();
            // par défaut lorque View n'a pas de param alors il appelle la vue qui 
            // porte le même nom que l'action
        }
        //public IActionResult Privacy()
        //{
        //    
        //    return View();
        //}

        public string Privacy()
        {
                       // return $"hello , nous sommes {DateTime.Now}, il fait chaud 31°";
                        return "hello , nous sommes"+ DateTime.Now+" , il fait chaud 31°";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}