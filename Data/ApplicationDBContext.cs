using API_ProyectoP1_Gimnasio_ProgramacionIV.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext
            (

                DbContextOptions<ApplicationDBContext> options

            ) : base(options) // Es como un super en herencia
        {



        }

        // Creo la tabla de esta manera en la DB
        public DbSet<Miembro> Miembro { get; set; }
        public DbSet<Membresia> Membresia { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Visita> Visita { get; set; }

        // Agregar datos a través de código con esta función
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Miembro>().HasData(

                    new Miembro
                    {

                        idMiembro = 1,
                        nombreMiembro = "Oscar",
                        apellidoMiembro = "Almeida",
                        emailMiembro = "oscar.almedia@udla.edu.ec",
                        fechaInscripcion = DateTime.Now
                        

                    },
                    new Miembro
                    {
                        idMiembro = 2,
                        nombreMiembro = "Diego",
                        apellidoMiembro = "Toscano",
                        emailMiembro = "diego.toscano@udla.edu.ec",
                        fechaInscripcion = DateTime.Now

                    }

                );
        }
        /*
         
            Siempre que haga una actualizacion en el DBContext debo hacer una migracion 

         */
    }
}
