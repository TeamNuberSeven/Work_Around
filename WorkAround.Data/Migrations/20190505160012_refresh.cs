using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkAround.Data.Migrations
{
    public partial class refresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthUser_WorkArea_WorkAreaId",
                table: "AuthUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Proffesion_AuthUser_AuthUserId",
                table: "Proffesion");

            migrationBuilder.DropForeignKey(
                name: "FK_Proffesion_WorkArea_WorkAreaId",
                table: "Proffesion");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_AuthUser_UserId",
                table: "Rate");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkArea_AuthUser_EmployeeId",
                table: "WorkArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkArea",
                table: "WorkArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rate",
                table: "Rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proffesion",
                table: "Proffesion");

            migrationBuilder.RenameTable(
                name: "WorkArea",
                newName: "WorkAreas");

            migrationBuilder.RenameTable(
                name: "Rate",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "Proffesion",
                newName: "Proffesions");

            migrationBuilder.RenameIndex(
                name: "IX_WorkArea_EmployeeId",
                table: "WorkAreas",
                newName: "IX_WorkAreas_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Rate_UserId",
                table: "Ratings",
                newName: "IX_Ratings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Proffesion_WorkAreaId",
                table: "Proffesions",
                newName: "IX_Proffesions_WorkAreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Proffesion_AuthUserId",
                table: "Proffesions",
                newName: "IX_Proffesions_AuthUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkAreas",
                table: "WorkAreas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proffesions",
                table: "Proffesions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AuthUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_AuthUser_AuthUserId",
                        column: x => x.AuthUserId,
                        principalTable: "AuthUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Sent = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ChatId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AuthUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AuthUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_AuthUserId",
                table: "Chats",
                column: "AuthUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthUser_WorkAreas_WorkAreaId",
                table: "AuthUser",
                column: "WorkAreaId",
                principalTable: "WorkAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proffesions_AuthUser_AuthUserId",
                table: "Proffesions",
                column: "AuthUserId",
                principalTable: "AuthUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proffesions_WorkAreas_WorkAreaId",
                table: "Proffesions",
                column: "WorkAreaId",
                principalTable: "WorkAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AuthUser_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "AuthUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAreas_AuthUser_EmployeeId",
                table: "WorkAreas",
                column: "EmployeeId",
                principalTable: "AuthUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthUser_WorkAreas_WorkAreaId",
                table: "AuthUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Proffesions_AuthUser_AuthUserId",
                table: "Proffesions");

            migrationBuilder.DropForeignKey(
                name: "FK_Proffesions_WorkAreas_WorkAreaId",
                table: "Proffesions");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AuthUser_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAreas_AuthUser_EmployeeId",
                table: "WorkAreas");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkAreas",
                table: "WorkAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proffesions",
                table: "Proffesions");

            migrationBuilder.RenameTable(
                name: "WorkAreas",
                newName: "WorkArea");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rate");

            migrationBuilder.RenameTable(
                name: "Proffesions",
                newName: "Proffesion");

            migrationBuilder.RenameIndex(
                name: "IX_WorkAreas_EmployeeId",
                table: "WorkArea",
                newName: "IX_WorkArea_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserId",
                table: "Rate",
                newName: "IX_Rate_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Proffesions_WorkAreaId",
                table: "Proffesion",
                newName: "IX_Proffesion_WorkAreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Proffesions_AuthUserId",
                table: "Proffesion",
                newName: "IX_Proffesion_AuthUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkArea",
                table: "WorkArea",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rate",
                table: "Rate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proffesion",
                table: "Proffesion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthUser_WorkArea_WorkAreaId",
                table: "AuthUser",
                column: "WorkAreaId",
                principalTable: "WorkArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proffesion_AuthUser_AuthUserId",
                table: "Proffesion",
                column: "AuthUserId",
                principalTable: "AuthUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proffesion_WorkArea_WorkAreaId",
                table: "Proffesion",
                column: "WorkAreaId",
                principalTable: "WorkArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_AuthUser_UserId",
                table: "Rate",
                column: "UserId",
                principalTable: "AuthUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkArea_AuthUser_EmployeeId",
                table: "WorkArea",
                column: "EmployeeId",
                principalTable: "AuthUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
