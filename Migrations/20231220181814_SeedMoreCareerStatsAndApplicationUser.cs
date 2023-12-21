using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CapstoneBlazorServerSite.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreCareerStatsAndApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "hij432", 0, "459c5708-e8c8-405f-8b16-fe56963ca639", "ao@ao.com", false, false, null, "AO@AO.COM", "ALPHAOMEGA", "AQAAAAIAAYagAAAAEDqdGvoj2fxZqiNfzP6aRfOReRsvCs6B8Man0I8ddZ6kx4quqm357Zzpx8XTRjPauQ==", null, false, "93d9310d-5f67-4490-b3c6-fc1c863689a8", false, "AlphaOmega" });

            migrationBuilder.InsertData(
                table: "CareerStats",
                columns: new[] { "PlayerId", "CareerMinutesPlayed", "CareerNumberOfWords", "CareerPointsPerMinute", "CareerPointsPerWord", "CareerScore", "HighScore", "PlayerName" },
                values: new object[,]
                {
                    { "hij432", 372.0, 419u, 8.599462365591398, 7.0, 3199u, 313u, "AlphaOmega" },
                    { "klm123", 100.0, 175u, 6.9800000000000004, 3.0, 698u, 71u, "Player L" },
                    { "nop456", 200.0, 250u, 4.0, 3.0, 800u, 100u, "Player M" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "hij432");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "hij432");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "klm123");

            migrationBuilder.DeleteData(
                table: "CareerStats",
                keyColumn: "PlayerId",
                keyValue: "nop456");
        }
    }
}
