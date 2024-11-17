using Ejercicio01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio01.Controllers
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
            SqlConnection miConexion = new SqlConnection();

            try

            {

                miConexion.ConnectionString
                = "server=amaro.database.windows.net;database=amaroDB;uid=usuario;pwd=LaCampana123;trustServerCertificate = true;";

                miConexion.Open();

            }
            catch (Exception ex)
            {
                // TODO
                // return View("Error");
            }
            return View();
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
