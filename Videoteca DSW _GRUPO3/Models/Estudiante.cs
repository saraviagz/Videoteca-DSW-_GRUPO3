﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("TB_estudiante")]  // Asegúrate de que este nombre coincida con el de la tabla en la base de datos
    public class Estudiante
    {
        [Key]
        public int id_estudiante { get; set; }
        public required string nombre { get; set; }
        public required string correo { get; set; }
        public required string contrasenia { get; set; }
        public required string estado { get; set; }
    }
}