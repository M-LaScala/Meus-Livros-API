using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeusLivrosAPI.Migrations;

/// <inheritdoc />
public partial class CriandoTabelaDeLivro : Migration
{
    /// <inheritdoc />
    /// Gerado a partir do Add-Migration
    /// Persistido no banco a partir do 
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Livros",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Titulo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Autor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Editora = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                QtdPaginas = table.Column<int>(type: "int", nullable: false),
                AnoDePublicacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                Genero = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Lido = table.Column<bool>(type: "tinyint(1)", nullable: false),
                Nota = table.Column<short>(type: "smallint", nullable: false),
                Review = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Livros", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Livros");
    }
}
