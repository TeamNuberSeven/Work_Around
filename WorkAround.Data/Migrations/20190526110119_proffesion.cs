using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkAround.Data.Migrations
{
    public partial class proffesion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employers_WorkAreas_WorkAreaId",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAreas_Employees_EmployeeId",
                table: "WorkAreas");

            migrationBuilder.DropIndex(
                name: "IX_WorkAreas_EmployeeId",
                table: "WorkAreas");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "WorkAreas");

            migrationBuilder.RenameColumn(
                name: "WorkAreaId",
                table: "Employers",
                newName: "ProffesionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employers_WorkAreaId",
                table: "Employers",
                newName: "IX_Employers_ProffesionId");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Proffesions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proffesions_EmployeeId",
                table: "Proffesions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_Proffesions_ProffesionId",
                table: "Employers",
                column: "ProffesionId",
                principalTable: "Proffesions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proffesions_Employees_EmployeeId",
                table: "Proffesions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Proffesions_ProffesionId",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_Proffesions_Employees_EmployeeId",
                table: "Proffesions");

            migrationBuilder.DropIndex(
                name: "IX_Proffesions_EmployeeId",
                table: "Proffesions");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Proffesions");

            migrationBuilder.RenameColumn(
                name: "ProffesionId",
                table: "Employers",
                newName: "WorkAreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Employers_ProffesionId",
                table: "Employers",
                newName: "IX_Employers_WorkAreaId");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "WorkAreas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkAreas_EmployeeId",
                table: "WorkAreas",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_WorkAreas_WorkAreaId",
                table: "Employers",
                column: "WorkAreaId",
                principalTable: "WorkAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAreas_Employees_EmployeeId",
                table: "WorkAreas",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
