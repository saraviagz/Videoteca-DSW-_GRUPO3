using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Videoteca_DSW__GRUPO3.Models;

namespace Videoteca_DSW__GRUPO3.Controllers
{
    public class EquipoController : Controller
    {
        private readonly AppDbContext _context;

        public EquipoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Equipo
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Equipos.Include(e => e.Administrador).Include(e => e.Inventario);
            return View(await appDbContext.ToListAsync());
        }

        public IActionResult Search(string type, string term)
        {
            var equipos = _context.Equipos.AsQueryable();

            if (!string.IsNullOrEmpty(term))
            {
                if (type == "nombre")
                {
                    equipos = equipos.Where(e => e.nombre_equipo.Contains(term));
                }
            }

            return View("Index", equipos.ToList());
        }

        // GET: Equipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .Include(e => e.Administrador)
                .Include(e => e.Inventario)
                .FirstOrDefaultAsync(m => m.id_equipo == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: Equipo/Create
        public IActionResult Create()
        {
            ViewData["id_admin"] = new SelectList(_context.Administradores, "id_admin", "nombre");
            ViewData["id_inventario"] = new SelectList(_context.Inventarios, "id_inventario", "id_inventario");
            return View();
        }

        // POST: Equipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_equipo,id_inventario,id_admin,codigo_pantalla,codigo_cpu,codigo_teclado,codigo_mouse,num_labo,codigo_en_labo,estado")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_admin"] = new SelectList(_context.Administradores, "id_admin", "id_admin", equipo.id_admin);
            ViewData["id_inventario"] = new SelectList(_context.Inventarios, "id_inventario", "id_inventario", equipo.id_inventario);
            return View(equipo);
        }*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_equipo,id_inventario,id_admin,codigo_pantalla,codigo_cpu,codigo_teclado,codigo_mouse,num_labo,codigo_en_labo,estado")] Equipo equipo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(equipo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Si el modelo no es válido, mostrar información detallada de los errores de validación.
                    foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        ModelState.AddModelError(string.Empty, modelError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log de la excepción para depuración
                ModelState.AddModelError(string.Empty, $"Ocurrió un error inesperado: {ex.Message}");
            }

            // Volver a cargar las listas desplegables
            ViewData["id_admin"] = new SelectList(_context.Administradores, "id_admin", "nombre", equipo.id_admin);
            ViewData["id_inventario"] = new SelectList(_context.Inventarios, "id_inventario", "id_inventario", equipo.id_inventario);

            return View(equipo);
        }


        // GET: Equipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            ViewData["id_admin"] = new SelectList(_context.Administradores, "id_admin", "id_admin", equipo.id_admin);
            ViewData["id_inventario"] = new SelectList(_context.Inventarios, "id_inventario", "id_inventario", equipo.id_inventario);
            return View(equipo);
        }

        // POST: Equipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_equipo,id_inventario,id_admin,codigo_pantalla,codigo_cpu,codigo_teclado,codigo_mouse,num_labo,codigo_en_labo,estado")] Equipo equipo)
        {
            if (id != equipo.id_equipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.id_equipo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_admin"] = new SelectList(_context.Administradores, "id_admin", "id_admin", equipo.id_admin);
            ViewData["id_inventario"] = new SelectList(_context.Inventarios, "id_inventario", "id_inventario", equipo.id_inventario);
            return View(equipo);
        }

        // GET: Equipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .Include(e => e.Administrador)
                .Include(e => e.Inventario)
                .FirstOrDefaultAsync(m => m.id_equipo == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo != null)
            {
                _context.Equipos.Remove(equipo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.id_equipo == id);
        }
    }
}
