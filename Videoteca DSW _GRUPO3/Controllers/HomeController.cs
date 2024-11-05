using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        // Muestra la página de inicio de sesión
        [HttpGet]
        
          public IActionResult Login()
        {
            return View(); // Asegúrate de tener Login.cshtml
        }


        // Lógica de autenticación cuando el usuario intenta iniciar sesión
   
      
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
                // Si es administrador, guarda sus datos y redirige al panel de administración
                TempData["Nombre"] = administrador.nombre;
                TempData["Correo"] = administrador.correo;
                return View("~/Views/Administrador/AdminDashboard.cshtml");

            }
            else if (estudiante != null)
            {
                // Si es estudiante, guarda sus datos y redirige al panel de estudiantes
                TempData["Nombre"] = estudiante.nombre;
                TempData["Correo"] = estudiante.correo;
                return View("~/Views/Estudiante/StudentDashboard.cshtml");
            }
            else
            {
                // Si las credenciales son incorrectas, muestra un mensaje de error
                ViewData["Mensaje"] = "Correo o contraseña incorrectos.";
                return View(); // Retorna la misma vista de Login con el mensaje de error
            }

 

        }

        // Panel de administración
        public IActionResult AdminDashboard(string option)
        {

                    return View("~/Views/Administrador/Inventario.cshtml");
             
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

        // Página de inicio
        public IActionResult Index()
        {
            return View(); // Vista principal de la aplicación
        }
        // Página de Privacy
        public IActionResult Privacy()
        {
            return View();

        }

        public IActionResult Perfil()
        {
            return View("~/Views/Administrador/Perfil.cshtml");
            
        }

        public IActionResult Reportes()
        {
            return View("~/Views/Administrador/Reportes.cshtml");
        }

        public IActionResult GestionarUsuarios()
        {
            return View("~/Views/Administrador/GestionarUsuarios.cshtml");
        }

        public IActionResult Inventario()
        {
            return View("~/Views/Administrador/Inventario.cshtml");   
        }

        public IActionResult Salir()
        {
            TempData.Clear();
            return RedirectToAction("Login");
        }
    }


}


