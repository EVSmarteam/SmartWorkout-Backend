using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkout_Backend.Migrations
{
    public partial class AlterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonitorExercise");

            migrationBuilder.AddColumn<string>(
                name: "WearableId",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ExerciseMonitor",
                columns: table => new
                {
                    ExerciseMonitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeartRate = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMonitor", x => x.ExerciseMonitorId);
                    table.ForeignKey(
                        name: "FK_ExerciseMonitor_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExcerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMonitor_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMonitor_ExerciseId",
                table: "ExerciseMonitor",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMonitor_UserId",
                table: "ExerciseMonitor",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMonitor");

            migrationBuilder.DropColumn(
                name: "WearableId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "MonitorExercise",
                columns: table => new
                {
                    MonitorExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeartRate = table.Column<float>(type: "real", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitorExercise", x => x.MonitorExerciseId);
                    table.ForeignKey(
                        name: "FK_MonitorExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExcerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonitorExercise_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonitorExercise_ExerciseId",
                table: "MonitorExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitorExercise_UserId",
                table: "MonitorExercise",
                column: "UserId");
        }
    }
}
