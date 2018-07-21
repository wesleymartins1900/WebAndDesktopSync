using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infra.Data.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SyncSequences",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Concluido = table.Column<bool>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DtoJson = table.Column<string>(nullable: true),
                    EntidadeId = table.Column<Guid>(nullable: false),
                    EntidadeNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncSequences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Sync = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitante", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SyncSequences");

            migrationBuilder.DropTable(
                name: "Visitante");
        }
    }
}
