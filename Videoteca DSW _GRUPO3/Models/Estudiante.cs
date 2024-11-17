using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("Tabla_estudiante")]
    public class Estudiante
    {
        [Key]
        public int id_estudiante { get; set; }
        public required string nombre { get; set; }
        public required string estado { get; set; }
        public required string correo { get; set; }
        public required string contrasenia { get; set; }
    }
}