using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Solution.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MockDataBase : Migration
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
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
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
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
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
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
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
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "usuariosRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuariosRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuariosRoles_usuarios_userId",
                        column: x => x.userId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Faccoes",
                columns: new[] { "Id", "NivelAmeaca", "Nome", "StatusDiplomatico" },
                values: new object[,]
                {
                    { -8L, "Alto", "Sindicatos Hutt", "Neutro" },
                    { -7L, "Medio", "Clãs Mandalorianos", "Neutro" },
                    { -6L, "Medio", "Guilda de Caçadores", "Neutro" },
                    { -5L, "Medio", "Resistência", "Pacifico" },
                    { -4L, "Alto", "Primeira Ordem", "Agressivo" },
                    { -3L, "Baixo", "Nova República", "Pacifico" },
                    { -2L, "Alto", "Aliança Rebelde", "Pacifico" },
                    { -1L, "Alto", "Império Galáctico", "Agressivo" }
                });

            migrationBuilder.InsertData(
                table: "Pilotos",
                columns: new[] { "Id", "Nome", "Patente" },
                values: new object[,]
                {
                    { -12L, "Garven Dreis", "Capitao" },
                    { -11L, "Wes Janson", "Tenente" },
                    { -10L, "Tycho Celchu", "Tenente" },
                    { -9L, "Jyn Erso", "Tenente" },
                    { -8L, "Cassian Andor", "Capitao" },
                    { -7L, "Leia Organa", "Capitao" },
                    { -6L, "Han Solo", "Tenente" },
                    { -5L, "Jek Porkins", "Tenente" },
                    { -4L, "Biggs Darklighter", "Tenente" },
                    { -3L, "Poe Dameron", "Capitao" },
                    { -2L, "Wedge Antilles", "Tenente" },
                    { -1L, "Luke Skywalker", "Capitao" }
                });

            migrationBuilder.InsertData(
                table: "Tripulantes",
                columns: new[] { "Id", "Especialidade", "Nome", "Patente" },
                values: new object[,]
                {
                    { -19L, "Batalha", "Hera Syndulla", "Capitao" },
                    { -18L, "Engenharia", "Sabine Wren", "Tenente" },
                    { -17L, "Medicina", "Jyn Erso", "Tenente" },
                    { -16L, "Medicina", "Cassian Andor", "Capitao" },
                    { -15L, "Engenharia", "Bodhi Rook", "Tenente" },
                    { -14L, "Engenharia", "Nien Nunb", "Tenente" },
                    { -13L, "Batalha", "Lando Calrissian", "Capitao" },
                    { -12L, "Engenharia", "Dak Ralter", "Cadete" },
                    { -11L, "Batalha", "Jek Porkins", "Tenente" },
                    { -10L, "Medicina", "Biggs Darklighter", "Tenente" },
                    { -9L, "Engenharia", "Rose Tico", "Cadete" },
                    { -8L, "Batalha", "Rey", "Tenente" },
                    { -7L, "Medicina", "Finn", "Cadete" },
                    { -6L, "Estrategista", "Poe Dameron", "Capitao" },
                    { -5L, "Engenharia", "Han Solo", "Tenente" },
                    { -4L, "Batalha", "Leia Organa", "Capitao" },
                    { -3L, "Engenharia", "Chewbacca", "Tenente" },
                    { -2L, "Medicina", "Wedge Antilles", "Tenente" },
                    { -1L, "Estrategista", "Luke Skywalker", "Capitao" }
                });

            migrationBuilder.InsertData(
                table: "Naves",
                columns: new[] { "Id", "CapacidadeTripulacao", "Classe", "FaccaoId", "Nome", "Status" },
                values: new object[,]
                {
                    { -13L, 90L, "Utilitario", -8L, "Khetanna", "Pronta" },
                    { -12L, 1L, "Patrulha", -7L, "Gauntlet Fighter", "Pronta" },
                    { -11L, 1L, "Utilitario", -6L, "Slave I", "Pronta" },
                    { -10L, 60000L, "CruzadorDeBatalha", -2L, "Finalizer (SD FO)", "EmReparo" },
                    { -9L, 1L, "Patrulha", -4L, "TIE Squadron", "Pronta" },
                    { -8L, 28000L, "CruzadorDeBatalha", -2L, "Interdictor", "Pronta" },
                    { -7L, 37000L, "CruzadorDeBatalha", -6L, "Devastator (ISD)", "Pronta" },
                    { -6L, 2L, "Patrulha", -1L, "Gold Leader (Y-Wing)", "EmReparo" },
                    { -5L, 1L, "Patrulha", -2L, "Red Five (X-Wing)", "Pronta" },
                    { -4L, 6L, "Utilitario", -5L, "Ghost", "Pronta" },
                    { -3L, 6L, "Utilitario", -4L, "Millennium Falcon", "Pronta" },
                    { -2L, 5200L, "CruzadorDeBatalha", -2L, "Liberty (MC80)", "Pronta" },
                    { -1L, 5400L, "CruzadorDeBatalha", -1L, "Home One", "Pronta" }
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

            migrationBuilder.CreateIndex(
                name: "IX_usuariosRoles_userId",
                table: "usuariosRoles",
                column: "userId");
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
                name: "usuariosRoles");

            migrationBuilder.DropTable(
                name: "relatorioCombate");

            migrationBuilder.DropTable(
                name: "missoes");

            migrationBuilder.DropTable(
                name: "Faccoes");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
