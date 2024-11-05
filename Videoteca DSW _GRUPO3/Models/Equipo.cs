using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("TB_equipo")]  // Asegúrate de que este nombre coincida con el de la tabla en la base de datos
    public class Equipo
    {
        [Key]
        public int id_equipo { get; set; }
        public required int id_inventario { get; set; }
        public required int id_admin { get; set; }
        public required string info_panatalla { get; set; }
        public required string info_cpu { get; set; }
        public required string info_teclado { get; set; }
        public required string info_mouse { get; set; }
        public required string info_etiqueta{ get; set; }
        public required string info_estado { get; set; }



    }
}