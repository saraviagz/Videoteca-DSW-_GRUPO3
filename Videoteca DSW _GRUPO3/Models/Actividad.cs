using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("TB_actividad")]  // Asegúrate de que este nombre coincida con el de la tabla en la base de datos
    public class Actividad
    {
        [Key]
        public int id_ { get; set; }
        public required string fecha { get; set; }
        public required string actividad { get; set; }
    }
}