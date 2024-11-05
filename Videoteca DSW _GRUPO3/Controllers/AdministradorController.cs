using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Videoteca_DSW__GRUPO3.Models;

namespace Videoteca_DSW__GRUPO3.Controllers
{
    public class AdministradorController : Controller
    {
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
            return View("~/Views/Home/Login.cshtml");
        }
    }
}
