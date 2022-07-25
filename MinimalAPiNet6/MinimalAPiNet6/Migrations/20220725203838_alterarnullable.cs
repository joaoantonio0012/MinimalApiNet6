using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPiNet6.Migrations
{
    public partial class alterarnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeFantasia = table.Column<string>(type: "TEXT", nullable: true),
                    RazaoSocial = table.Column<string>(type: "TEXT", nullable: true),
                    CpfCnpj = table.Column<string>(type: "TEXT", nullable: true),
                    DataDeCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Armazem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    UnidadesDeArmazenamentoMaxima = table.Column<long>(type: "INTEGER", nullable: false),
                    UnidadesDeArmazenamentoOcupadas = table.Column<long>(type: "INTEGER", nullable: false),
                    Localizacao = table.Column<string>(type: "TEXT", nullable: true),
                    HoraInicioDeRecebimentoDeCarga = table.Column<int>(type: "INTEGER", nullable: false),
                    HoraFinalDeRecebimentoDeCarga = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpresaModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    DataDeCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armazem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armazem_Empresa_EmpresaModelId",
                        column: x => x.EmpresaModelId,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArmazemId = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeMotorista = table.Column<string>(type: "TEXT", nullable: true),
                    CpfMotorista = table.Column<string>(type: "TEXT", nullable: true),
                    Placa = table.Column<string>(type: "TEXT", nullable: true),
                    TipoDeCarga = table.Column<int>(type: "INTEGER", nullable: false),
                    DataDeAgendamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NomePorteiroEntrada = table.Column<string>(type: "TEXT", nullable: true),
                    CancelaEntrada = table.Column<int>(type: "INTEGER", nullable: true),
                    NomePorteiroSaida = table.Column<string>(type: "TEXT", nullable: true),
                    CancelaSaida = table.Column<int>(type: "INTEGER", nullable: true),
                    UnidadesDeArmazenamentoDaCarga = table.Column<int>(type: "INTEGER", nullable: true),
                    TempoEstimadoParaDescarregar = table.Column<int>(type: "INTEGER", nullable: true),
                    DataEHoraDeChegada = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataEHoraDeSaida = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TempoDePermanenciaDentroDoArmazem = table.Column<string>(type: "TEXT", nullable: true),
                    DataDeCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carga_Armazem_ArmazemId",
                        column: x => x.ArmazemId,
                        principalTable: "Armazem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carga_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armazem_EmpresaModelId",
                table: "Armazem",
                column: "EmpresaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Carga_ArmazemId",
                table: "Carga",
                column: "ArmazemId");

            migrationBuilder.CreateIndex(
                name: "IX_Carga_EmpresaId",
                table: "Carga",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carga");

            migrationBuilder.DropTable(
                name: "Armazem");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
