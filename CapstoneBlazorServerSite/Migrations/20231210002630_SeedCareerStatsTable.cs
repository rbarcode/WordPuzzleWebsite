using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CapstoneBlazorServerSite.Migrations
{
    /// <inheritdoc />
    public partial class SeedCareerStatsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "CareerPointsPerWord",
                table: "CareerStats",
                type: "double",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "CareerPointsPerMinute",
                table: "CareerStats",
                type: "double",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "CareerMinutesPlayed",
                table: "CareerStats",
                type: "double",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned");

            migrationBuilder.InsertData(
                table: "CareerStats",
                columns: new[] { "PlayerId", "CareerMinutesPlayed", "CareerNumberOfWords", "CareerPointsPerMinute", "CareerPointsPerWord", "CareerScore", "HighScore", "PlayerName" },
                values: new object[,]
                {
                    { "abc123", 315.0, 450u, 10.476190476190476, 7.0, 3300u, 375u, "Player A" },
                    { "bcd098", 663.72000000000003, 775u, 11.186946302657747, 9.0, 7425u, 832u, "Player J" },
                    { "def456", 175.0, 230u, 5.1428571428571432, 3.0, 900u, 112u, "Player B" },
                    { "efg765", 1025.9100000000001, 2716u, 8.6440331023189163, 3.0, 8868u, 158u, "Player K" },
                    { "ghi789", 1037.4400000000001, 941u, 5.7767196175200493, 6.0, 5993u, 749u, "Player C" },
                    { "jkl098", 401.88900000000001, 233u, 2.0328996314902872, 3.0, 817u, 206u, "Player D" },
                    { "mno765", 698.17100000000005, 827u, 9.9001534008144123, 8.0, 6912u, 571u, "Player E" },
                    { "pqr432", 506.47399999999999, 769u, 9.9866923079960674, 6.0, 5058u, 445u, "Player F" },
                    { "stu123", 714.62699999999995, 1738u, 10.843419014394923, 4.0, 7749u, 603u, "Player G" },
                    { "vwx456", 552.20600000000002, 642u, 7.5424750908175566, 6.0, 4165u, 592u, "Player H" },
                    { "yza789", 112.983, 194u, 6.6912721382862905, 3.0, 756u, 93u, "Player I" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "abc123");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "bcd098");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "def456");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "efg765");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "ghi789");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "jkl098");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "mno765");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "pqr432");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "stu123");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "vwx456");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "yza789");

            migrationBuilder.AlterColumn<float>(
                name: "CareerPointsPerWord",
                table: "CareerStats",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<float>(
                name: "CareerPointsPerMinute",
                table: "CareerStats",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<uint>(
                name: "CareerMinutesPlayed",
                table: "CareerStats",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
