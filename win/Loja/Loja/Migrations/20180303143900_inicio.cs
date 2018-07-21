using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Loja.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SyncSequence",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Concluido = table.Column<bool>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    DtoJson = table.Column<string>(nullable: true),
                    EntidadeId = table.Column<Guid>(nullable: false),
                    EntidadeNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncSequence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    Logradouro = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visita",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VisitanteId = table.Column<int>(nullable: false),
                    VisitanteId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visita_Visitante_VisitanteId1",
                        column: x => x.VisitanteId1,
                        principalTable: "Visitante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visita_VisitanteId1",
                table: "Visita",
                column: "VisitanteId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SyncSequence");

            migrationBuilder.DropTable(
                name: "Visita");

            migrationBuilder.DropTable(
                name: "Visitante");
        }
    }
}
