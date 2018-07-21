﻿// <auto-generated />
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Infra.Data.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20180721222924_inicio")]
    partial class inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Sync.SyncSequence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Concluido");

                    b.Property<DateTime>("DataDeCadastro");

                    b.Property<string>("DtoJson");

                    b.Property<Guid>("EntidadeId");

                    b.Property<string>("EntidadeNome");

                    b.HasKey("Id");

                    b.ToTable("SyncSequences");
                });

            modelBuilder.Entity("Domain.Entities.Visitantes.Visitante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Logradouro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Sync");

                    b.HasKey("Id");

                    b.ToTable("Visitante");
                });
#pragma warning restore 612, 618
        }
    }
}