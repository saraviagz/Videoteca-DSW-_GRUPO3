using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("Equipo")]
    public class Equipo
    {
        [Key]
        public int id_equipo { get; set; }

        [ForeignKey("Inventario")]
        public int? id_inventario { get; set; }
        public virtual Inventario Inventario { get; set; }

        [ForeignKey("Administrador")]
        public int? id_admin { get; set; }
        public virtual Administrador Administrador { get; set; }

        [Required]
        [StringLength(50)]
        public string codigo_pantalla { get; set; }

        [Required]
        [StringLength(50)]
        public string codigo_cpu { get; set; }

        [Required]
        [StringLength(50)]
        public string codigo_teclado { get; set; }

        [Required]
        [StringLength(50)]
        public string codigo_mouse { get; set; }

        public int num_labo { get; set; }

        [Required]
        public int codigo_en_labo { get; set; }

        [Required]
        [StringLength(20)]
        public string estado { get; set; } = "libre";

        public string nombre_equipo { get; set; }
    }
}