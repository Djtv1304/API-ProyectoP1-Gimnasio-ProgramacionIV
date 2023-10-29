﻿// <auto-generated />
using System;
using API_ProyectoP1_Gimnasio_ProgramacionIV.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20231029004220_nuevasTablasYObjetos")]
    partial class nuevasTablasYObjetos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_ProyectoP1_Gimnasio_ProgramacionIV.Models.Membresia", b =>
                {
                    b.Property<int>("idMembresia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idMembresia"));

                    b.Property<int>("duracionMembresia")
                        .HasColumnType("int");

                    b.Property<string>("nombreMembresia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precioMembresia")
                        .HasColumnType("float");

                    b.HasKey("idMembresia");

                    b.ToTable("Membresia");

                    b.HasData(
                        new
                        {
                            idMembresia = 1,
                            duracionMembresia = 12,
                            nombreMembresia = "Membresia Oro",
                            precioMembresia = 100.0
                        },
                        new
                        {
                            idMembresia = 2,
                            duracionMembresia = 6,
                            nombreMembresia = "Membresia Plata",
                            precioMembresia = 60.0
                        },
                        new
                        {
                            idMembresia = 3,
                            duracionMembresia = 3,
                            nombreMembresia = "Membresia Bronce",
                            precioMembresia = 30.0
                        });
                });

            modelBuilder.Entity("API_ProyectoP1_Gimnasio_ProgramacionIV.Models.Miembro", b =>
                {
                    b.Property<int>("idMiembro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idMiembro"));

                    b.Property<string>("apellidoMiembro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emailMiembro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<int>("idMembresia")
                        .HasColumnType("int");

                    b.Property<string>("nombreMiembro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idMiembro");

                    b.HasIndex("idMembresia");

                    b.ToTable("Miembro");

                    b.HasData(
                        new
                        {
                            idMiembro = 1,
                            apellidoMiembro = "Almeida",
                            emailMiembro = "oscar.almedia@udla.edu.ec",
                            fechaInscripcion = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            idMembresia = 1,
                            nombreMiembro = "Oscar"
                        },
                        new
                        {
                            idMiembro = 2,
                            apellidoMiembro = "Toscano",
                            emailMiembro = "diego.toscano@udla.edu.ec",
                            fechaInscripcion = new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            idMembresia = 2,
                            nombreMiembro = "Diego"
                        });
                });

            modelBuilder.Entity("API_ProyectoP1_Gimnasio_ProgramacionIV.Models.Pago", b =>
                {
                    b.Property<int>("idPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPago"));

                    b.Property<DateTime>("caducidadTarjeta")
                        .HasColumnType("datetime2");

                    b.Property<string>("cvvTarjeta")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime>("fechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("miembroId")
                        .HasColumnType("int");

                    b.Property<double>("montoPago")
                        .HasColumnType("float");

                    b.Property<string>("numeroTarjeta")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("nvarchar(19)");

                    b.Property<string>("tipoTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titularTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idPago");

                    b.ToTable("Pago");

                    b.HasData(
                        new
                        {
                            idPago = 1,
                            caducidadTarjeta = new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            cvvTarjeta = "123",
                            fechaPago = new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            miembroId = 1,
                            montoPago = 193.0,
                            numeroTarjeta = "123456789048000",
                            tipoTarjeta = "Mastercard",
                            titularTarjeta = "Diego Toscano"
                        },
                        new
                        {
                            idPago = 2,
                            caducidadTarjeta = new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            cvvTarjeta = "321",
                            fechaPago = new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            miembroId = 2,
                            montoPago = 200.0,
                            numeroTarjeta = "123456789048975",
                            tipoTarjeta = "Visa",
                            titularTarjeta = "Steeven Teran"
                        });
                });

            modelBuilder.Entity("API_ProyectoP1_Gimnasio_ProgramacionIV.Models.Visita", b =>
                {
                    b.Property<int>("idVisita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVisita"));

                    b.Property<string>("descripcionVisita")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaVisita")
                        .HasColumnType("datetime2");

                    b.Property<int>("miembroId")
                        .HasColumnType("int");

                    b.HasKey("idVisita");

                    b.ToTable("Visita");

                    b.HasData(
                        new
                        {
                            idVisita = 1,
                            descripcionVisita = "Descp Visita 1",
                            fechaVisita = new DateTime(2023, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            miembroId = 1
                        },
                        new
                        {
                            idVisita = 2,
                            descripcionVisita = "Descp Visita 2",
                            fechaVisita = new DateTime(2023, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            miembroId = 1
                        },
                        new
                        {
                            idVisita = 3,
                            descripcionVisita = "Descp Visita 3",
                            fechaVisita = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            miembroId = 2
                        });
                });

            modelBuilder.Entity("API_ProyectoP1_Gimnasio_ProgramacionIV.Models.Miembro", b =>
                {
                    b.HasOne("API_ProyectoP1_Gimnasio_ProgramacionIV.Models.Membresia", "Membresia")
                        .WithMany("Miembros")
                        .HasForeignKey("idMembresia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membresia");
                });

            modelBuilder.Entity("API_ProyectoP1_Gimnasio_ProgramacionIV.Models.Membresia", b =>
                {
                    b.Navigation("Miembros");
                });
#pragma warning restore 612, 618
        }
    }
}
