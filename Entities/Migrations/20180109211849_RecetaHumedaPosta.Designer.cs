﻿// <auto-generated />
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Entities.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20180109211849_RecetaHumedaPosta")]
    partial class RecetaHumedaPosta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direccion");

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefono");

                    b.HasKey("ID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Entities.Operario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefono");

                    b.HasKey("ID");

                    b.ToTable("Operarios");
                });

            modelBuilder.Entity("Entities.Partida", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CantSinClasificar");

                    b.Property<int>("Cantidad");

                    b.Property<DateTime>("FechaIngreso");

                    b.Property<string>("Observaciones");

                    b.Property<decimal>("PesoPromedio");

                    b.Property<string>("Tipo");

                    b.HasKey("ID");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("Entities.Pedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteID");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Entities.ProcesoHumedo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("Fin");

                    b.Property<TimeSpan>("Inicio");

                    b.Property<int>("Proceso");

                    b.Property<int>("SubPartidaID");

                    b.HasKey("ID");

                    b.HasIndex("SubPartidaID");

                    b.ToTable("ProcesosHumedos");
                });

            modelBuilder.Entity("Entities.SubPartida", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Calidad");

                    b.Property<int>("CantCueros");

                    b.Property<decimal?>("Eficiencia");

                    b.Property<string>("Estado");

                    b.Property<int>("PartidaID");

                    b.Property<int?>("PedidoID");

                    b.Property<int?>("Stock");

                    b.HasKey("ID");

                    b.HasIndex("PartidaID");

                    b.HasIndex("PedidoID")
                        .IsUnique()
                        .HasFilter("[PedidoID] IS NOT NULL");

                    b.ToTable("SubPartidas");
                });

            modelBuilder.Entity("Entities.Pedido", b =>
                {
                    b.HasOne("Entities.Cliente", "Cliente")
                        .WithMany("Pedido")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.ProcesoHumedo", b =>
                {
                    b.HasOne("Entities.SubPartida", "SubPartida")
                        .WithMany()
                        .HasForeignKey("SubPartidaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.SubPartida", b =>
                {
                    b.HasOne("Entities.Partida", "Partida")
                        .WithMany("SubPartidas")
                        .HasForeignKey("PartidaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Pedido", "Pedido")
                        .WithOne("SubPartida")
                        .HasForeignKey("Entities.SubPartida", "PedidoID");
                });
#pragma warning restore 612, 618
        }
    }
}
