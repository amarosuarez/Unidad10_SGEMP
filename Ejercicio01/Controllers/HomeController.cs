using Ejercicio01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DAL_EJ01;
using Microsoft.Data.SqlClient;

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
            return View();
        }

        [HttpPost]
        public ActionResult Conexion()
        {
            SqlConnection _conexion = new SqlConnection();

            try
            {
                _conexion = clsConexionDB.getConexion();
                if (_conexion.State == System.Data.ConnectionState.Open)
                {
                    ViewBag.estado = "Conexión exitosa";
                }
                else
                {
                    ViewBag.estado = "Error: la conexión no pudo establecerse";
                }
            }
            catch (Exception ex)
            {
                ViewBag.estado = "Error al intentar conectar con la base de datos";
            }
            finally
            {
                _conexion.Close();
            }

            return View("Index");
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
