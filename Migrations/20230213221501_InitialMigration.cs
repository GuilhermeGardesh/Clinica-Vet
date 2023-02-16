using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVet.GestaoVeterinaria.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicoVeterinario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NumeroDeIncricaoCRMV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalDoCRMV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoVeterinario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContatoPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContatoSecundario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lagradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especie = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Raca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ProprietarioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Proprietario_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnostico = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ObservacoesIniciais = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ObservacoesFinais = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    AtendimentoIniciado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtendimentoFinalizado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false),
                    IdAnimal = table.Column<int>(type: "int", nullable: false),
                    IdMedicoVeterinario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimento_Animal_IdAnimal",
                        column: x => x.IdAnimal,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimento_MedicoVeterinario_IdMedicoVeterinario",
                        column: x => x.IdMedicoVeterinario,
                        principalTable: "MedicoVeterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ProprietarioId",
                table: "Animal",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_IdAnimal",
                table: "Atendimento",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_IdMedicoVeterinario",
                table: "Atendimento",
                column: "IdMedicoVeterinario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "MedicoVeterinario");

            migrationBuilder.DropTable(
                name: "Proprietario");
        }
    }
}
