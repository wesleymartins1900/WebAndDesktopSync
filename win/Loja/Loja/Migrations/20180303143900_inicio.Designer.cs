﻿// <auto-generated />
using Loja.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Loja.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20180303143900_inicio")]
    partial class inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Loja.Domain.Sync.SyncSequence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Concluido");

                    b.Property<DateTime>("DataDeCadastro");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("DtoJson");

                    b.Property<Guid>("EntidadeId");

                    b.Property<string>("EntidadeNome");

                    b.HasKey("Id");

                    b.ToTable("SyncSequence");

                    b.HasDiscriminator<string>("Discriminator").HasValue("SyncSequence");
                });

            modelBuilder.Entity("Loja.Domain.Visita", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("VisitanteId");

                    b.Property<Guid?>("VisitanteId1");

                    b.HasKey("Id");

                    b.HasIndex("VisitanteId1");

                    b.ToTable("Visita");
                });

            modelBuilder.Entity("Loja.Domain.Visitante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataDeCadastro");

                    b.Property<string>("Logradouro");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Visitante");
                });

            modelBuilder.Entity("Loja.Domain.Sync.SyncPost", b =>
                {
                    b.HasBaseType("Loja.Domain.Sync.SyncSequence");


                    b.ToTable("SyncPost");

                    b.HasDiscriminator().HasValue("SyncPost");
                });

            modelBuilder.Entity("Loja.Domain.Sync.SyncPut", b =>
                {
                    b.HasBaseType("Loja.Domain.Sync.SyncSequence");


                    b.ToTable("SyncPut");

                    b.HasDiscriminator().HasValue("SyncPut");
                });

            modelBuilder.Entity("Loja.Domain.Visita", b =>
                {
                    b.HasOne("Loja.Domain.Visitante", "Visitante")
                        .WithMany()
                        .HasForeignKey("VisitanteId1");
                });
#pragma warning restore 612, 618
        }
    }
}
