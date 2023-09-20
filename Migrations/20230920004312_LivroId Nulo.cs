using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeusLivrosAPI.Migrations
{
    /// <inheritdoc />
    public partial class LivroIdNulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Livros_LivroId",
                table: "Lancamento");

            migrationBuilder.AlterColumn<int>(
                name: "LivroId",
                table: "Lancamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Livros_LivroId",
                table: "Lancamento",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Livros_LivroId",
                table: "Lancamento");

            migrationBuilder.AlterColumn<int>(
                name: "LivroId",
                table: "Lancamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Livros_LivroId",
                table: "Lancamento",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
