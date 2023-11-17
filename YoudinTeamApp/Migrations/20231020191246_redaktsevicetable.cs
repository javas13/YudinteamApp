using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoudinTeamApp.Migrations
{
    public partial class redaktsevicetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Services",
                newName: "Display_Order");

            migrationBuilder.AddColumn<string>(
                name: "Short_Description",
                table: "Services",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Short_Description",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Display_Order",
                table: "Services",
                newName: "DisplayOrder");
        }
    }
}
