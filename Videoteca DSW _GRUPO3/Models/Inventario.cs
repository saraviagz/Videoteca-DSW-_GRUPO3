using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("TB_inventario")]  // Asegúrate de que este nombre coincida con el de la tabla en la base de datos
    public class Inventario
    {
        [Key]
        public required int id_inventario { get; set; }
        public required int num_lab{ get; set; }
        public required int num_equip { get; set; }

    }
}