using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeManager.FridgesMicroService.Migrations
{
    public partial class addedownerstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerEmail",
                table: "Fridges");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Fridges");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Fridges",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    MailingConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_OwnerId",
                table: "Fridges",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fridges_Owners_OwnerId",
                table: "Fridges",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fridges_Owners_OwnerId",
                table: "Fridges");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Fridges_OwnerId",
                table: "Fridges");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Fridges");

            migrationBuilder.AddColumn<string>(
                name: "OwnerEmail",
                table: "Fridges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Fridges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
