﻿using System.ComponentModel.DataAnnotations;

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Models
{
    public class Miembro
    {

        [Key]
        public int idMiembro { get; set; }

        [Required]
        public string nombreMiembro { get; set; }

        [Required]
        public string apellidoMiembro { get; set; }

        [Required, EmailAddress]
        public string emailMiembro { get; set; }

        [Required]
        public DateTime fechaInscripcion {  get; set; }

    }
}