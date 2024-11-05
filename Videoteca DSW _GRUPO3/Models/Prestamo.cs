using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("TB_prestamo")]  // Asegúrate de que este nombre coincida con el de la tabla en la base de datos
    public class Prestamo
    {
        [Key]
        public int id_prestamo { get; set; }
        public required int id_estudiante { get; set; }
        public required int id_equipo { get; set; }
        public required string estado { get; set; }
        public required DateTime fecha { get; set; }
        public required TimeSpan hora_inicio_porestamo { get; set; }
        public required TimeSpan hora_fin_prestamo { get; set; }
        public required int tiempo_pedido { get; set; }
        public required int tiempo_usado { get; set; }


}
}