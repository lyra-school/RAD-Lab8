using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoSharingConsole.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollaborativeEvent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborativeEvent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Creator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Handle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TargetAudience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageViewsPerHour = table.Column<double>(type: "float", nullable: false),
                    AverageCommentsPerHour = table.Column<double>(type: "float", nullable: false),
                    AveragePercentageWatchtime = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CollaborativeEventCreator",
                columns: table => new
                {
                    CreatorsID = table.Column<int>(type: "int", nullable: false),
                    EventsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborativeEventCreator", x => new { x.CreatorsID, x.EventsID });
                    table.ForeignKey(
                        name: "FK_CollaborativeEventCreator_CollaborativeEvent_EventsID",
                        column: x => x.EventsID,
                        principalTable: "CollaborativeEvent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollaborativeEventCreator_Creator_CreatorsID",
                        column: x => x.CreatorsID,
                        principalTable: "Creator",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    LengthInSeconds = table.Column<int>(type: "int", nullable: false),
                    StatisticsID = table.Column<int>(type: "int", nullable: false),
                    CreatorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Video_Creator_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Creator",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Video_Statistics_StatisticsID",
                        column: x => x.StatisticsID,
                        principalTable: "Statistics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollaborativeEventCreator_EventsID",
                table: "CollaborativeEventCreator",
                column: "EventsID");

            migrationBuilder.CreateIndex(
                name: "IX_Video_CreatorID",
                table: "Video",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Video_StatisticsID",
                table: "Video",
                column: "StatisticsID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaborativeEventCreator");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "CollaborativeEvent");

            migrationBuilder.DropTable(
                name: "Creator");

            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}
