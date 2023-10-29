using System.ComponentModel.DataAnnotations;

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Models
{
    public class Membresia
    {
        [Key]
        public int idMembresia { get; set; }

        public ICollection<Miembro> Miembros { get; set; }

        [Required]
        public string nombreMembresia { get; set; }

        [Required]
        public int duracionMembresia { get; set; } // 12 meses, o con un if puedo cambiar a un año y demás 

        [Required]
        public double precioMembresia { get; set; }
    }
}
