using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_K2iP.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adquirente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adquirente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bandeira",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bandeira", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdquirenteId = table.Column<int>(nullable: false),
                    CodigoCliente = table.Column<string>(nullable: true),
                    DataTransacao = table.Column<string>(nullable: true),
                    HoraTransacao = table.Column<string>(nullable: true),
                    NumeroCartao = table.Column<string>(nullable: true),
                    CodigoAutorizacao = table.Column<string>(nullable: true),
                    NSU = table.Column<string>(nullable: true),
                    BandeiraId = table.Column<int>(nullable: false),
                    ValorBruto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxaAdmin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorLiquido = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transacoes_Adquirente_AdquirenteId",
                        column: x => x.AdquirenteId,
                        principalTable: "Adquirente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacoes_Bandeira_BandeiraId",
                        column: x => x.BandeiraId,
                        principalTable: "Bandeira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_AdquirenteId",
                table: "Transacoes",
                column: "AdquirenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_BandeiraId",
                table: "Transacoes",
                column: "BandeiraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "Adquirente");

            migrationBuilder.DropTable(
                name: "Bandeira");
        }
    }
}
