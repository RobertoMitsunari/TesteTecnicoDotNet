using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteTecnicoDotNet.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorInicialFinanciamento",
                table: "Financiamento",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorInicialFinanciamento",
                table: "Financiamento");
        }
    }
}
