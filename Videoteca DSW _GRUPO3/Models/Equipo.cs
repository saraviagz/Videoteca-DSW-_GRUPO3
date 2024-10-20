using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("TB_equipo")]  // Asegúrate de que este nombre coincida con el de la tabla en la base de datos
    public class Equipo
    {
        [Key]
        public int id_equipo { get; set; }
        public required string info_pantalla { get; set; }
        public required string info_cpu { get; set; }
        public required string info_teclado { get; set; }
        public required string info_mause { get; set; }
        public required string etiqueta { get; set; }
        public required string estado { get; set; }
    }
}