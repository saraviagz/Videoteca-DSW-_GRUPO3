using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videoteca_DSW__GRUPO3.Models
{
    [Table("Equipo")]
    public class Equipo
    {
        [Key]
        public int id_equipo { get; set; }

        // Relación con la tabla Inventario (id_inventario es clave foránea)
        [ForeignKey("Inventario")]
        public int id_inventario { get; set; }
        public Inventario Inventario { get; set; }

        // Relación con la tabla Administrador (id_admin es clave foránea)
        [ForeignKey("Administrador")]
        public int id_admin { get; set; }
        public Administrador Administrador { get; set; }

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
        public string estado { get; set; } = "libre";  // Valor por defecto "libre"
    }
}
