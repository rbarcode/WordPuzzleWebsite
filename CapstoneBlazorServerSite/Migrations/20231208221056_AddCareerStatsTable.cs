using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneBlazorServerSite.Migrations
{
    /// <inheritdoc />
    public partial class AddCareerStatsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareerStats",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlayerId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlayerName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HighScore = table.Column<uint>(type: "int unsigned", nullable: false),
                    CareerScore = table.Column<uint>(type: "int unsigned", nullable: false),
                    CareerMinutesPlayed = table.Column<uint>(type: "int unsigned", nullable: false),
                    CareerPointsPerMinute = table.Column<float>(type: "float", nullable: false),
                    CareerNumberOfWords = table.Column<uint>(type: "int unsigned", nullable: false),
                    CareerPointsPerWord = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerStats", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareerStats");
        }
    }
}
