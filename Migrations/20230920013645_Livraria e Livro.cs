using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeusLivrosAPI.Migrations
{
    /// <inheritdoc />
    public partial class LivrariaeLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Livrarias_LivrariaId",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Livros_LivroId",
                table: "Lancamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lancamento",
                table: "Lancamento");

            migrationBuilder.DropIndex(
                name: "IX_Lancamento_LivroId",
                table: "Lancamento");

            migrationBuilder.DropColumn(
                name: "Id",
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

            migrationBuilder.AlterColumn<int>(
                name: "LivrariaId",
                table: "Lancamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lancamento",
                table: "Lancamento",
                columns: new[] { "LivroId", "LivrariaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Livrarias_LivrariaId",
                table: "Lancamento",
                column: "LivrariaId",
                principalTable: "Livrarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Livros_LivroId",
                table: "Lancamento",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Livrarias_LivrariaId",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Livros_LivroId",
                table: "Lancamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lancamento",
                table: "Lancamento");

            migrationBuilder.AlterColumn<int>(
                name: "LivrariaId",
                table: "Lancamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LivroId",
                table: "Lancamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Lancamento",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lancamento",
                table: "Lancamento",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_LivroId",
                table: "Lancamento",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Livrarias_LivrariaId",
                table: "Lancamento",
                column: "LivrariaId",
                principalTable: "Livrarias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Livros_LivroId",
                table: "Lancamento",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "id");
        }
    }
}
