using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckDrivingDetails.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyDrivingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrivingTime = table.Column<double>(type: "float", nullable: false),
                    BreakingTime = table.Column<double>(type: "float", nullable: false),
                    BreakState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDrivingDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyDrivingViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrivingTime = table.Column<double>(type: "float", nullable: false),
                    TimeBreak = table.Column<double>(type: "float", nullable: false),
                    BreakState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDrivingViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CDRulesViolations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    ViolationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDRulesViolations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CDRulesViolations_DailyDrivingViewModel_DriverId",
                        column: x => x.DriverId,
                        principalTable: "DailyDrivingViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CDRulesViolations_DriverId",
                table: "CDRulesViolations",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CDRulesViolations");

            migrationBuilder.DropTable(
                name: "DailyDrivingDetails");

            migrationBuilder.DropTable(
                name: "DailyDrivingViewModel");
        }
    }
}
