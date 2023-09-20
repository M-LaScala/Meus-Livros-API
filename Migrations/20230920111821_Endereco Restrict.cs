using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeusLivrosAPI.Migrations
{
    /// <inheritdoc />
    public partial class EnderecoRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livrarias_Enderecos_EnderecoId",
                table: "Livrarias");

            migrationBuilder.AddForeignKey(
                name: "FK_Livrarias_Enderecos_EnderecoId",
                table: "Livrarias",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livrarias_Enderecos_EnderecoId",
                table: "Livrarias");

            migrationBuilder.AddForeignKey(
                name: "FK_Livrarias_Enderecos_EnderecoId",
                table: "Livrarias",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
