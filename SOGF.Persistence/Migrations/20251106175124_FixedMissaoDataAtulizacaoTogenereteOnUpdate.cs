using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixedMissaoDataAtulizacaoTogenereteOnUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faccoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    StatusDiplomatico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivelAmeaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faccoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "missoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjetivoMissao = table.Column<int>(type: "int", nullable: false),
                    SetorGalatico = table.Column<int>(type: "int", nullable: false),
                    StatusMissao = table.Column<int>(type: "int", nullable: false),
                    NaveId = table.Column<long>(type: "bigint", nullable: false),
                    PilotoId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_missoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilotos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Patente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "relatorioCombate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoTatica = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FaccaoVencedoraId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relatorioCombate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tripulantes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Patente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tripulantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Naves",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadeTripulacao = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaccaoId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Naves_Faccoes_FaccaoId",
                        column: x => x.FaccaoId,
                        principalTable: "Faccoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "missaoTripulantes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripulanteId = table.Column<long>(type: "bigint", nullable: false),
                    MissaoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_missaoTripulantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_missaoTripulantes_missoes_MissaoId",
                        column: x => x.MissaoId,
                        principalTable: "missoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngajamentosCombate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NaveId = table.Column<long>(type: "bigint", nullable: false),
                    PilotoId = table.Column<long>(type: "bigint", nullable: false),
                    RelatorioCombateId = table.Column<long>(type: "bigint", nullable: false),
                    MissaoId = table.Column<long>(type: "bigint", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngajamentosCombate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EngajamentosCombate_relatorioCombate_RelatorioCombateId",
                        column: x => x.RelatorioCombateId,
                        principalTable: "relatorioCombate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EngajamentosCombate_RelatorioCombateId_NaveId_PilotoId",
                table: "EngajamentosCombate",
                columns: new[] { "RelatorioCombateId", "NaveId", "PilotoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_missaoTripulantes_MissaoId_TripulanteId",
                table: "missaoTripulantes",
                columns: new[] { "MissaoId", "TripulanteId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Naves_FaccaoId",
                table: "Naves",
                column: "FaccaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EngajamentosCombate");

            migrationBuilder.DropTable(
                name: "missaoTripulantes");

            migrationBuilder.DropTable(
                name: "Naves");

            migrationBuilder.DropTable(
                name: "Pilotos");

            migrationBuilder.DropTable(
                name: "Tripulantes");

            migrationBuilder.DropTable(
                name: "relatorioCombate");

            migrationBuilder.DropTable(
                name: "missoes");

            migrationBuilder.DropTable(
                name: "Faccoes");
        }
    }
}
