using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("Inventario")]
    public class Inventario
    {
        [Key]
        public int id_inventario { get; set; }
        public int num_labo { get; set; }
        [Range(0, int.MaxValue)]
        public int num_equipos { get; set; }
    }
}
