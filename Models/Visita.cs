using System.ComponentModel.DataAnnotations;

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Models
{
    public class Visita
    {

        [Key]
        public int idVisita {  get; set; }

        [Required]
        public DateTime fechaVisita {  get; set; }

        [Required]
        public int miembroId {  get; set; }

        public string descripcionVisita {  get; set; }

    }
}
