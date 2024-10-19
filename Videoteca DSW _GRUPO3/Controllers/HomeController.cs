using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Videoteca_DSW__GRUPO3.Models;

namespace Videoteca_DSW__GRUPO3.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // Muestra la p�gina de inicio de sesi�n
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Aseg�rate de tener Login.cshtml
        }

        // L�gica de autenticaci�n cuando el usuario intenta iniciar sesi�n
        [HttpPost]
        public IActionResult Login(string correo, string password)
        {
            // Busca al administrador en la base de datos
            var administrador = _context.Administradores
                .FirstOrDefault(a => a.correo == correo && a.contrasenia == password);

            // Busca al estudiante en la base de datos
            var estudiante = _context.Estudiantes
                .FirstOrDefault(e => e.correo == correo && e.contrasenia == password);

            if (administrador != null)
            {
                // Si es administrador, guarda sus datos y redirige al panel de administraci�n
                TempData["Nombre"] = administrador.nombre;
                TempData["Correo"] = administrador.correo;
                return RedirectToAction("AdminDashboard");
            }
            else if (estudiante != null)
            {
                // Si es estudiante, guarda sus datos y redirige al panel de estudiantes
                TempData["Nombre"] = estudiante.nombre;
                TempData["Correo"] = estudiante.correo;
                return RedirectToAction("StudentDashboard");
            }
            else
            {
                // Si las credenciales son incorrectas, muestra un mensaje de error
                ViewData["Mensaje"] = "Correo o contraseña incorrectos.";
                return View(); // Retorna la misma vista de Login con el mensaje de error
            }
        }

        // Panel de administraci�n
        public IActionResult AdminDashboard()
        {
            if (TempData["Nombre"] == null || TempData["Correo"] == null)
            {
                // Redirige al login si no hay datos de administrador
                return RedirectToAction("Login");
            }

            return View(); // Vista de AdminDashboard
        }

        // Panel de estudiantes
        public IActionResult StudentDashboard()
        {
            if (TempData["Nombre"] == null || TempData["Correo"] == null)
            {
                // Redirige al login si no hay datos de estudiante
                return RedirectToAction("Login");
            }

            return View(); // Vista de StudentDashboard
        }

        // Manejo de errores
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // P�gina de inicio
        public IActionResult Index()
        {
            return View(); // Vista principal de la aplicaci�n
        }
        // P�gina de Privacy
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
