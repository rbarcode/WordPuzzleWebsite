using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneBlazorServerSite.Migrations
{
    /// <inheritdoc />
    public partial class UsePlayerIdAsKeyInCareerStatsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CareerStats",
                table: "CareerStats");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CareerStats");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "CareerStats",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CareerStats",
                table: "CareerStats",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CareerStats",
                table: "CareerStats");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "CareerStats",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "CareerStats",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CareerStats",
                table: "CareerStats",
                column: "Id");
        }
    }
}
