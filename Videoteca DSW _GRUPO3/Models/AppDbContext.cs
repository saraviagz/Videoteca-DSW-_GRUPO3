﻿using Microsoft.EntityFrameworkCore; // Asegúrate de tener esta referencia
using Videoteca_DSW__GRUPO3.Models;

namespace Videoteca_DSW__GRUPO3.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Administrador> Administradores { get; set; } // Refleja la tabla dbo.
        public DbSet<Estudiante> Estudiantes { get; set; } // Refleja la tabla dbo.
        public DbSet<Actividad> Actividades { get; set; } // Refleja la tabla dbo.
        public DbSet<Equipo> Equipos { get; set; } // Refleja la tabla dbo.
        public DbSet<Inventario> Inventarios { get; set; } // Refleja la tabla dbo.
        public DbSet<Prestamo> Prestamos { get; set; } // Refleja la tabla dbo.
    }
}
