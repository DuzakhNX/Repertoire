using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chauffeur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero_Camion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel_Togo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel_Benin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel_Niger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre_Camion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proprietaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero_Proprietaire = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeur", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chauffeur");
        }
    }
}
