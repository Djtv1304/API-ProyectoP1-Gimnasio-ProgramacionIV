using System.ComponentModel.DataAnnotations;

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Models
{
    public class Pago
    {

        [Key]
        public int idPago { get; set; }

        [Required]
        public int miembroId { get; set; }

        [Required]
        public DateTime fechaPago { get; set; }

        [Required]
        public double montoPago {  get; set; }

    }
}
