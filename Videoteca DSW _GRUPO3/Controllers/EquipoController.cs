using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Videoteca_DSW__GRUPO3.Models;

namespace Videoteca_DSW__GRUPO3.Controllers
{
    public class EquiposController : Controller
    {
        private readonly AppDbContext _context;

        public EquiposController(AppDbContext context)
        {
            _context = context;
        }

        // Mostrar lista de equipos
        public async Task<IActionResult> ListarEquipo()
        {
            var equipo = await _context.Equipos.ToListAsync();
            return View(equipo);
        }

        // Mostrar detalles de un equipo
        public async Task<IActionResult> Details(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // Crear un equipo (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Crear un equipo (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListarEquipo));
            }
            return View(equipo);
        }

        // Editar un equipo (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // Editar un equipo (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Equipo equipo)
        {
            if (id != equipo.id_equipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListarEquipo));
            }
            return View(equipo);
        }

        // Eliminar un equipo (GET)
        public async Task<IActionResult> Delete(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // Confirmar eliminación de equipo (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
