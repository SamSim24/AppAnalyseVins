using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP2_POO2.Migrations
{
    /// <inheritdoc />
    public partial class TP2_POO2DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oenologues",
                columns: table => new
                {
                    oenologueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppMDP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateNaissance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    civilite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oenologues", x => x.oenologueId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    clientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    oenologueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateNaissance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    civilite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.clientId);
                    table.ForeignKey(
                        name: "FK_Clients_Oenologues_oenologueId",
                        column: x => x.oenologueId,
                        principalTable: "Oenologues",
                        principalColumn: "oenologueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vins",
                columns: table => new
                {
                    vinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientId = table.Column<int>(type: "int", nullable: false),
                    alcool = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sulphate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    acideVolatile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    acideCitrique = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vins", x => x.vinId);
                    table.ForeignKey(
                        name: "FK_Vins_Clients_clientId",
                        column: x => x.clientId,
                        principalTable: "Clients",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Oenologues",
                columns: new[] { "oenologueId", "AppMDP", "adresse", "civilite", "dateNaissance", "nom", "pays", "prenom", "province", "ville" },
                values: new object[] { "1", "1234", "12", "Monsieur", "2003/10/24", "Samuel", "Canada", "Samuel", "Québec", "Lévis" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "clientId", "adresse", "civilite", "dateNaissance", "nom", "oenologueId", "pays", "prenom", "province", "ville" },
                values: new object[] { 1, "12", "Monsieur", "2003/10/24", "Samuel", "1", "Canada", "Samuel", "Québec", "Lévis" });

            migrationBuilder.InsertData(
                table: "Vins",
                columns: new[] { "vinId", "acideCitrique", "acideVolatile", "alcool", "clientId", "sulphate" },
                values: new object[] { 1, "0.25", "0.6", "9.8", 1, "0.53" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_oenologueId",
                table: "Clients",
                column: "oenologueId");

            migrationBuilder.CreateIndex(
                name: "IX_Vins_clientId",
                table: "Vins",
                column: "clientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vins");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Oenologues");
        }
    }
}
