using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace rentalMS2.Migrations
{
    public partial class NewCheckInTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EarlyCheckIn",
                columns: table => new
                {
                    EarlyCheckInId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CheckInDate = table.Column<DateTime>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarlyCheckIn", x => x.EarlyCheckInId);
                    table.ForeignKey(
                        name: "FK_EarlyCheckIn_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LateCheckOut",
                columns: table => new
                {
                    LateCheckOutId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CheckOutDate = table.Column<DateTime>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LateCheckOut", x => x.LateCheckOutId);
                    table.ForeignKey(
                        name: "FK_LateCheckOut_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EarlyCheckIn_UnitId",
                table: "EarlyCheckIn",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LateCheckOut_UnitId",
                table: "LateCheckOut",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EarlyCheckIn");

            migrationBuilder.DropTable(
                name: "LateCheckOut");
        }
    }
}
