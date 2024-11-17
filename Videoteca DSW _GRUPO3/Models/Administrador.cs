using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("Tabla_administrador")]  // Asegúrate de que este nombre coincida con el de la tabla en la base de datos
    public class Administrador
    {
        [Key]
        public int id_admin { get; set; }
        public required string nombre { get; set; }
        public required string correo { get; set; }
        public required string contrasenia { get; set; }
    }
}
