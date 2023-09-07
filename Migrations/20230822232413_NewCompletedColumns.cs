using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rentalMS2.Migrations
{
    public partial class NewCompletedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitDeepCleans_Unit_UnitId",
                table: "UnitDeepCleans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitDeepCleans",
                table: "UnitDeepCleans");

            migrationBuilder.RenameTable(
                name: "UnitDeepCleans",
                newName: "UnitDeepClean");

            migrationBuilder.RenameIndex(
                name: "IX_UnitDeepCleans_UnitId",
                table: "UnitDeepClean",
                newName: "IX_UnitDeepClean_UnitId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MaitenanceTask",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "MaitenanceTask",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Chore",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitDeepClean",
                table: "UnitDeepClean",
                column: "DeepCleanId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitDeepClean_Unit_UnitId",
                table: "UnitDeepClean",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitDeepClean_Unit_UnitId",
                table: "UnitDeepClean");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitDeepClean",
                table: "UnitDeepClean");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MaitenanceTask");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "MaitenanceTask");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Chore");

            migrationBuilder.RenameTable(
                name: "UnitDeepClean",
                newName: "UnitDeepCleans");

            migrationBuilder.RenameIndex(
                name: "IX_UnitDeepClean_UnitId",
                table: "UnitDeepCleans",
                newName: "IX_UnitDeepCleans_UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitDeepCleans",
                table: "UnitDeepCleans",
                column: "DeepCleanId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitDeepCleans_Unit_UnitId",
                table: "UnitDeepCleans",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
