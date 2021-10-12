using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oficina.Migrations
{
    public partial class Ordens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    DescricaoDefeito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoSolucao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrazo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecoTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordem_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordem_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_ClienteId",
                table: "Ordem",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_FuncionarioId",
                table: "Ordem",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordem");
        }
    }
}
