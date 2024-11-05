using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Videoteca_DSW__GRUPO3.Models;

namespace Videoteca_DSW__GRUPO3.Controllers
{
    public class EstudianteController : Controller
    {
        public IActionResult Perfil()
        {
            return View("~/Views/Estudiante/Perfil.cshtml");
        }

        public IActionResult ReservaEquipo()
        {
            return View("~/Views/Estudiante/ReservaEquipo.cshtml");
        }

        public IActionResult Historial()
        {
            return View("~/Views/Estudiante/Historial.cshtml");
        }

        public IActionResult Salir()
        {
            return View("~/Views/Home/Login.cshtml");
        }
    }
}
