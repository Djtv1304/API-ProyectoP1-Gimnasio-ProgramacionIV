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
                    idMembresia = 1, // Asigno la membresía Oro a Oscar
                    apellidoMiembro = "Almeida",
                    emailMiembro = "oscar.almedia@udla.edu.ec",
                    fechaInscripcion = DateTime.Parse("2024-03-15")
                },
                new Miembro
                {
                    idMiembro = 2,
                    nombreMiembro = "Diego",
                    idMembresia = 2, // Asigno la membresía Plata a Diego
                    apellidoMiembro = "Toscano",
                    emailMiembro = "diego.toscano@udla.edu.ec",
                    fechaInscripcion = DateTime.Parse("2024-04-15")
                }

            );

            modelBuilder.Entity<Visita>().HasData(

                new Visita
                {

                    idVisita = 1,
                    fechaVisita = DateTime.Parse("2023-11-27"),
                    descripcionVisita = "Descp Visita 1",
                    miembroId = 1,

                },
                new Visita
                {

                    idVisita = 2,
                    fechaVisita = DateTime.Parse("2023-11-28"),
                    descripcionVisita = "Descp Visita 2",
                    miembroId = 1,

                },
                new Visita
                {

                    idVisita = 3,
                    fechaVisita = DateTime.Parse("2023-11-29"),
                    descripcionVisita = "Descp Visita 3",
                    miembroId = 2,

                }

            );

            modelBuilder.Entity<Pago>().HasData(

                new Pago
                {

                    idPago = 1,
                    fechaPago = DateTime.Parse("2023-05-22"),
                    miembroId = 1,
                    montoPago = 193,
                    titularTarjeta = "Diego Toscano",
                    numeroTarjeta = "123456789048000",
                    caducidadTarjeta = DateTime.Parse("2024-05-22"),
                    cvvTarjeta = "123",
                    tipoTarjeta = "Mastercard"

                },
                new Pago
                {

                    idPago = 2,
                    fechaPago = DateTime.Parse("2023-06-22"),
                    miembroId = 2,
                    montoPago = 200,
                    titularTarjeta = "Steeven Teran",
                    numeroTarjeta = "123456789048975",
                    caducidadTarjeta = DateTime.Parse("2024-06-22"),
                    cvvTarjeta = "321",
                    tipoTarjeta = "Visa"

                }

            );

            modelBuilder.Entity<Membresia>().HasData(

                new Membresia
                {
                    idMembresia = 1,
                    nombreMembresia = "Membresia Oro",
                    duracionMembresia = 12,
                    precioMembresia = 100.0
                },
                new Membresia
                {
                    idMembresia = 2,
                    nombreMembresia = "Membresia Plata",
                    duracionMembresia = 6,
                    precioMembresia = 60.0
                },
                new Membresia
                {
                    idMembresia = 3,
                    nombreMembresia = "Membresia Bronce",
                    duracionMembresia = 3,
                    precioMembresia = 30.0
                }
            );

        }
        /*
         
            Siempre que haga una actualizacion en el DBContext debo hacer una migracion 

         */
    }
}
