using Ejercicio02ASP.Models;
using Ejercicio02ASP.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio02ASP.Controllers
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
            IActionResult result;

            try
            {
                listadoVM vistaModel = new listadoVM();
                result = View(vistaModel);
            }
            catch (Exception ex)
            {
                result = View("ErrorDB");
            }

            
            return result;
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
