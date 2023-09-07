using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace rentalMS2.Migrations
{
    public partial class NewDeepCleanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chores_Buildings_BuildingId",
                table: "Chores");

            migrationBuilder.DropForeignKey(
                name: "FK_Chores_Managers_ManagerId",
                table: "Chores");

            migrationBuilder.DropForeignKey(
                name: "FK_Chores_Units_UnitId",
                table: "Chores");

            migrationBuilder.DropForeignKey(
                name: "FK_MaitenanceTasks_Units_UnitId",
                table: "MaitenanceTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Buildings_BuildingId",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaitenanceTasks",
                table: "MaitenanceTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chores",
                table: "Chores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Chores");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Chores");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Chores");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Buildings");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "Manager");

            migrationBuilder.RenameTable(
                name: "MaitenanceTasks",
                newName: "MaitenanceTask");

            migrationBuilder.RenameTable(
                name: "Chores",
                newName: "Chore");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "Building");

            migrationBuilder.RenameIndex(
                name: "IX_Units_BuildingId",
                table: "Unit",
                newName: "IX_Unit_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_MaitenanceTasks_UnitId",
                table: "MaitenanceTask",
                newName: "IX_MaitenanceTask_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Chores_UnitId",
                table: "Chore",
                newName: "IX_Chore_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Chores_ManagerId",
                table: "Chore",
                newName: "IX_Chore_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Chores_BuildingId",
                table: "Chore",
                newName: "IX_Chore_BuildingId");

            migrationBuilder.AddColumn<string>(
                name: "UnitName",
                table: "Unit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Manager",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChoreDescription",
                table: "Chore",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChoreName",
                table: "Chore",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChorePriority",
                table: "Chore",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingName",
                table: "Building",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manager",
                table: "Manager",
                column: "ManagerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaitenanceTask",
                table: "MaitenanceTask",
                column: "MaitenanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chore",
                table: "Chore",
                column: "ChoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Building",
                table: "Building",
                column: "BuildingId");

            migrationBuilder.CreateTable(
                name: "UnitDeepCleans",
                columns: table => new
                {
                    DeepCleanId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeepCleanDate = table.Column<DateTime>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitDeepCleans", x => x.DeepCleanId);
                    table.ForeignKey(
                        name: "FK_UnitDeepCleans_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitDeepCleans_UnitId",
                table: "UnitDeepCleans",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chore_Building_BuildingId",
                table: "Chore",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chore_Manager_ManagerId",
                table: "Chore",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chore_Unit_UnitId",
                table: "Chore",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaitenanceTask_Unit_UnitId",
                table: "MaitenanceTask",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Building_BuildingId",
                table: "Unit",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chore_Building_BuildingId",
                table: "Chore");

            migrationBuilder.DropForeignKey(
                name: "FK_Chore_Manager_ManagerId",
                table: "Chore");

            migrationBuilder.DropForeignKey(
                name: "FK_Chore_Unit_UnitId",
                table: "Chore");

            migrationBuilder.DropForeignKey(
                name: "FK_MaitenanceTask_Unit_UnitId",
                table: "MaitenanceTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Building_BuildingId",
                table: "Unit");

            migrationBuilder.DropTable(
                name: "UnitDeepCleans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manager",
                table: "Manager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaitenanceTask",
                table: "MaitenanceTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chore",
                table: "Chore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Building",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "UnitName",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "ChoreDescription",
                table: "Chore");

            migrationBuilder.DropColumn(
                name: "ChoreName",
                table: "Chore");

            migrationBuilder.DropColumn(
                name: "ChorePriority",
                table: "Chore");

            migrationBuilder.DropColumn(
                name: "BuildingName",
                table: "Building");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "Manager",
                newName: "Managers");

            migrationBuilder.RenameTable(
                name: "MaitenanceTask",
                newName: "MaitenanceTasks");

            migrationBuilder.RenameTable(
                name: "Chore",
                newName: "Chores");

            migrationBuilder.RenameTable(
                name: "Building",
                newName: "Buildings");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_BuildingId",
                table: "Units",
                newName: "IX_Units_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_MaitenanceTask_UnitId",
                table: "MaitenanceTasks",
                newName: "IX_MaitenanceTasks_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Chore_UnitId",
                table: "Chores",
                newName: "IX_Chores_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Chore_ManagerId",
                table: "Chores",
                newName: "IX_Chores_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Chore_BuildingId",
                table: "Chores",
                newName: "IX_Chores_BuildingId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Units",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Managers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Chores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Chores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Chores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Buildings",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "ManagerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaitenanceTasks",
                table: "MaitenanceTasks",
                column: "MaitenanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chores",
                table: "Chores",
                column: "ChoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chores_Buildings_BuildingId",
                table: "Chores",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chores_Managers_ManagerId",
                table: "Chores",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chores_Units_UnitId",
                table: "Chores",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaitenanceTasks_Units_UnitId",
                table: "MaitenanceTasks",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Buildings_BuildingId",
                table: "Units",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
