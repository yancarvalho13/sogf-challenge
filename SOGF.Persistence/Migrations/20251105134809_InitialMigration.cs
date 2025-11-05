using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Naves",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "missoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaveDesignadaId = table.Column<long>(type: "bigint", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_missoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_missoes_Naves_NaveDesignadaId",
                        column: x => x.NaveDesignadaId,
                        principalTable: "Naves",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tripulantes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Patente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavePilotadaId = table.Column<long>(type: "bigint", nullable: true),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaveAtualId = table.Column<long>(type: "bigint", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tripulantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tripulantes_Naves_NaveAtualId",
                        column: x => x.NaveAtualId,
                        principalTable: "Naves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tripulantes_Naves_NavePilotadaId",
                        column: x => x.NavePilotadaId,
                        principalTable: "Naves",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "relatorioCombate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoDeEventos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PilotoVencedorId = table.Column<long>(type: "bigint", nullable: false),
                    PilotoPerdedorId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relatorioCombate", x => x.Id);
                    table.CheckConstraint("CK_PilotoVencedorId_PilotoPerdedorId", "[PilotoVencedorId] <> [PilotoPerdedorId]");
                    table.ForeignKey(
                        name: "FK_relatorioCombate_Tripulantes_PilotoPerdedorId",
                        column: x => x.PilotoPerdedorId,
                        principalTable: "Tripulantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_relatorioCombate_Tripulantes_PilotoVencedorId",
                        column: x => x.PilotoVencedorId,
                        principalTable: "Tripulantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_missoes_NaveDesignadaId",
                table: "missoes",
                column: "NaveDesignadaId");

            migrationBuilder.CreateIndex(
                name: "IX_relatorioCombate_PilotoPerdedorId",
                table: "relatorioCombate",
                column: "PilotoPerdedorId");

            migrationBuilder.CreateIndex(
                name: "IX_relatorioCombate_PilotoVencedorId_PilotoPerdedorId",
                table: "relatorioCombate",
                columns: new[] { "PilotoVencedorId", "PilotoPerdedorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tripulantes_NaveAtualId",
                table: "Tripulantes",
                column: "NaveAtualId");

            migrationBuilder.CreateIndex(
                name: "IX_Tripulantes_NavePilotadaId",
                table: "Tripulantes",
                column: "NavePilotadaId",
                unique: true,
                filter: "[NavePilotadaId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "missoes");

            migrationBuilder.DropTable(
                name: "relatorioCombate");

            migrationBuilder.DropTable(
                name: "Tripulantes");

            migrationBuilder.DropTable(
                name: "Naves");
        }
    }
}
