using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrabantPongASP.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Spelers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Rankings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Clubs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Spelers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Rankings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Clubs");
        }
    }
}
