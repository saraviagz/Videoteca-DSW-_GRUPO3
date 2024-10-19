using Microsoft.EntityFrameworkCore;
using Videoteca_DSW__GRUPO3.Models;

namespace Videoteca_DSW__GRUPO3.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Administrador> Administradores { get; set; } // Refleja la tabla dbo.Administrador
        public DbSet<Estudiante > Estudiantes { get; set; } // Refleja la tabla dbo.Administrador
        public DbSet<Inventario> Inventarios { get; set; } // Refleja la tabla dbo.Inventario
        public DbSet<Equipo> Equipos { get; set; }
    }
}
