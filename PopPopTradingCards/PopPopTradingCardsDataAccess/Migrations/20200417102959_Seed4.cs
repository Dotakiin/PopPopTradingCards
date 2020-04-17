using Microsoft.EntityFrameworkCore.Migrations;

namespace PopPopTradingCardsDataAccess.Migrations
{
    public partial class Seed4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BaseballCard",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "/Images/Mickey_Mantle1952.jpg");

            migrationBuilder.UpdateData(
                table: "BaseballCard",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "/Images/Mickey_Mantle1952.jpg");

            migrationBuilder.UpdateData(
                table: "BaseballCard",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "/Images/Mickey_Mantle1952.jpg");

            migrationBuilder.UpdateData(
                table: "MagicCard",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "/Images/Vampire_Knighthawk_Zendikar.jfif");

            migrationBuilder.UpdateData(
                table: "MagicCard",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "/Images/Vampire_Knighthawk_Zendikar.jfif");

            migrationBuilder.UpdateData(
                table: "MagicCard",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "/Images/Vampire_Knighthawk_Zendikar.jfif");

            migrationBuilder.UpdateData(
                table: "MagicCard",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "/Images/Ob_Nixilis_the_Fallen.jpg");

            migrationBuilder.UpdateData(
                table: "MagicCard",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "/Images/Ob_Nixilis_the_Fallen.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BaseballCard",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "Images/Mickey_Mantle1952.jpg");

            migrationBuilder.UpdateData(
                table: "BaseballCard",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "Images/Mickey_Mantle1952.jpg");

            migrationBuilder.UpdateData(
                table: "BaseballCard",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "Images/Mickey_Mantle1952.jpg");

            migrationBuilder.UpdateData(
                table: "MagicCard",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "Images/Vampire_Knighthawk_Zendikar.jfif");

            migrationBuilder.UpdateData(
                table: "MagicCard",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "Images/Vampire_Knighthawk_Zendikar.jfif");

            migrationBuilder.UpdateData(
                table: "MagicCard",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "Images/Vampire_Knighthawk_Zendikar.jfif");

            migrationBuilder.UpdateData(
                table: "MagicCard",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "Images/Ob_Nixilis_the_Fallen.jpg");

            migrationBuilder.UpdateData(
                table: "MagicCard",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "Images/Ob_Nixilis_the_Fallen.jpg");
        }
    }
}
