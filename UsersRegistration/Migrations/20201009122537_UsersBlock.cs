using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersRegistration.Migrations
{
    public partial class UsersBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Block",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Block",
                table: "AspNetUsers");
        }
    }
}
