using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIHospitalCP05.Migrations
{
    /// <inheritdoc />
    public partial class HopsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeCompleto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataNascimento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "PLANO_DE_SAUDE",
                columns: table => new
                {
                    IdPlanoDeSaude = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomePlano = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CodPlano = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cobertura = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PacienteIdPaciente = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLANO_DE_SAUDE", x => x.IdPlanoDeSaude);
                    table.ForeignKey(
                        name: "FK_PLANO_DE_SAUDE_PACIENTE_PacienteIdPaciente",
                        column: x => x.PacienteIdPaciente,
                        principalTable: "PACIENTE",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLANO_DE_SAUDE_PacienteIdPaciente",
                table: "PLANO_DE_SAUDE",
                column: "PacienteIdPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PLANO_DE_SAUDE");

            migrationBuilder.DropTable(
                name: "PACIENTE");
        }
    }
}
