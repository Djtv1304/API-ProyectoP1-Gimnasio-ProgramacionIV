using System.ComponentModel.DataAnnotations;

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
