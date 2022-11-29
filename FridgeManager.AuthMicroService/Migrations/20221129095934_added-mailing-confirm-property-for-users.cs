using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeManager.AuthMicroService.Migrations
{
    public partial class addedmailingconfirmpropertyforusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MailingConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0f2e668f-9378-47a7-8aaf-831b46921073"),
                column: "ConcurrencyStamp",
                value: "a9e22f61-9d3d-4a94-be1c-931bae76beb5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("71efaeea-3b0b-49e4-a0fe-136bb7c1d29c"),
                column: "ConcurrencyStamp",
                value: "e99944be-3992-49c2-8dbe-63513b3417ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eaebb81d-d857-4928-82a2-2528d9148aa4"),
                column: "ConcurrencyStamp",
                value: "909bbe49-bb28-443a-b473-79ab421ed836");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailingConfirmed",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0f2e668f-9378-47a7-8aaf-831b46921073"),
                column: "ConcurrencyStamp",
                value: "8ea1ec39-7c96-4916-9ba4-9c1c244c9f6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("71efaeea-3b0b-49e4-a0fe-136bb7c1d29c"),
                column: "ConcurrencyStamp",
                value: "7d527720-e39c-4cc8-82cc-dda545aafd60");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eaebb81d-d857-4928-82a2-2528d9148aa4"),
                column: "ConcurrencyStamp",
                value: "9de2381e-ba49-4fe0-bada-02ac2cbbc6b9");
        }
    }
}
