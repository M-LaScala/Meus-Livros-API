using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeusLivrosAPI.Migrations
{
    /// <inheritdoc />
    public partial class LancamentoeLivraria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LivrariaId",
                table: "Lancamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_LivrariaId",
                table: "Lancamento",
                column: "LivrariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Livrarias_LivrariaId",
                table: "Lancamento",
                column: "LivrariaId",
                principalTable: "Livrarias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Livrarias_LivrariaId",
                table: "Lancamento");

            migrationBuilder.DropIndex(
                name: "IX_Lancamento_LivrariaId",
                table: "Lancamento");

            migrationBuilder.DropColumn(
                name: "LivrariaId",
                table: "Lancamento");
        }
    }
}
