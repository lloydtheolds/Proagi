﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proagil.Repository;

namespace Proagil.Repository.Migrations
{
    [DbContext(typeof(ProagilContext))]
    [Migration("20211027184407_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Proagil.Domain.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataEvento");

                    b.Property<string>("Email");

                    b.Property<string>("ImagemURL");

                    b.Property<string>("Local");

                    b.Property<int>("QtdPessoas");

                    b.Property<string>("Telefone");

                    b.Property<string>("Tema");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Proagil.Domain.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataFinal");

                    b.Property<DateTime?>("DataInicio");

                    b.Property<int>("EventoId");

                    b.Property<string>("Nome");

                    b.Property<decimal>("Preco");

                    b.Property<int>("quantidade");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("Proagil.Domain.Palestrante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("ImagemURL");

                    b.Property<string>("MiniCurriculo");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Palestrantes");
                });

            modelBuilder.Entity("Proagil.Domain.PalestranteEvento", b =>
                {
                    b.Property<int>("EventoId");

                    b.Property<int>("PalestranteId");

                    b.HasKey("EventoId", "PalestranteId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("PalestranteEventos");
                });

            modelBuilder.Entity("Proagil.Domain.RedeSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventoId");

                    b.Property<string>("Nome");

                    b.Property<int?>("PalestranteId");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("RedesSociais");
                });

            modelBuilder.Entity("Proagil.Domain.Lote", b =>
                {
                    b.HasOne("Proagil.Domain.Evento", "Evento")
                        .WithMany("Lotes")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Proagil.Domain.PalestranteEvento", b =>
                {
                    b.HasOne("Proagil.Domain.Evento", "Evento")
                        .WithMany("PalestrantesEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Proagil.Domain.Palestrante", "Palestrante")
                        .WithMany()
                        .HasForeignKey("PalestranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Proagil.Domain.RedeSocial", b =>
                {
                    b.HasOne("Proagil.Domain.Evento", "Evento")
                        .WithMany("RedesSociais")
                        .HasForeignKey("EventoId");

                    b.HasOne("Proagil.Domain.Palestrante", "Palestrante")
                        .WithMany("RedesSociais")
                        .HasForeignKey("PalestranteId");
                });
#pragma warning restore 612, 618
        }
    }
}
