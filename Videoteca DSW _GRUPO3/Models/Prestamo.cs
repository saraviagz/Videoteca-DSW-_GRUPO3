using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("TB_prestamo")]  // Asegúrate de que este nombre coincida con el de la tabla en la base de datos
    public class Prestamo
    {
        [Key]
        public int id_prestamo { get; set; }
        public required string estado { get; set; }
        public required string fecha { get; set; }
        public required string hora_inicio_prestamo { get; set; }
        public required string tiempo_pedido { get; set; }
        public required string hora_fin_prestamo { get; set; }
        public required string tiempo_usado { get; set; }
    }
}