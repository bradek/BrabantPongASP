using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrabantPongASP.Data.Migrations
{
    /// <inheritdoc />
    public partial class KeyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scheidsrechters",
                columns: table => new
                {
                    ScheidsrechterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheidsrechterNaam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheidsrechters", x => x.ScheidsrechterId);
                });

            migrationBuilder.CreateTable(
                name: "Toernooien",
                columns: table => new
                {
                    ToernooiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToernooiNaam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toernooien", x => x.ToernooiId);
                });

            migrationBuilder.CreateTable(
                name: "ToernooiScheidsrechters",
                columns: table => new
                {
                    ToernooiScheidsrechterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToernooiId = table.Column<int>(type: "int", nullable: false),
                    ScheidsrechterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToernooiScheidsrechters", x => x.ToernooiScheidsrechterId);
                    table.ForeignKey(
                        name: "FK_ToernooiScheidsrechters_Scheidsrechters_ScheidsrechterId",
                        column: x => x.ScheidsrechterId,
                        principalTable: "Scheidsrechters",
                        principalColumn: "ScheidsrechterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToernooiScheidsrechters_Toernooien_ToernooiId",
                        column: x => x.ToernooiId,
                        principalTable: "Toernooien",
                        principalColumn: "ToernooiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToernooiScheidsrechters_ScheidsrechterId",
                table: "ToernooiScheidsrechters",
                column: "ScheidsrechterId");

            migrationBuilder.CreateIndex(
                name: "IX_ToernooiScheidsrechters_ToernooiId",
                table: "ToernooiScheidsrechters",
                column: "ToernooiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToernooiScheidsrechters");

            migrationBuilder.DropTable(
                name: "Scheidsrechters");

            migrationBuilder.DropTable(
                name: "Toernooien");
        }
    }
}
