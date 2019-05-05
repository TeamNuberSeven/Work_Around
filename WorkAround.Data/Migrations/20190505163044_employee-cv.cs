using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkAround.Data.Migrations
{
    public partial class employeecv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CVUrl",
                table: "AuthUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVUrl",
                table: "AuthUser");
        }
    }
}
