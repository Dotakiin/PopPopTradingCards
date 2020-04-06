using Microsoft.EntityFrameworkCore.Migrations;

namespace PopPopTradingCardsDataAccess.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TradingCardTracker");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "TradingCardTracker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseballCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    PlayerName = table.Column<string>(nullable: false),
                    Team = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseballCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseballCard_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "TradingCardTracker",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagicCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    CMC = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Rarity = table.Column<string>(nullable: true),
                    Booster = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicCard_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "TradingCardTracker",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "TradingCardTracker",
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { -1, "CardList", "CardList" },
                    { 1, "Magic", "Magic" },
                    { 2, "Baseball", "Baseball" },
                    { 3, "Both", "Both" },
                    { 4, "Cardless", "Cardless" }
                });

            migrationBuilder.InsertData(
                table: "BaseballCard",
                columns: new[] { "Id", "Image", "Location", "PlayerName", "Team", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, "C:/Users/ZFisher-LegionY530/Desktop/PopPopTradingCards/PopPopTradingCards/PopPopTradingCards/Images/Mickey_Mantle1952.jpg", "Red box in Attic", "Micky Mantle", "New York Yankees", -1, 1952 },
                    { 2, "C:/Users/ZFisher-LegionY530/Desktop/PopPopTradingCards/PopPopTradingCards/PopPopTradingCards/Images/Mickey_Mantle1952.jpg", "Red box in Attic", "Micky Mantle", "New York Yankees", 2, 1952 },
                    { 3, "C:/Users/ZFisher-LegionY530/Desktop/PopPopTradingCards/PopPopTradingCards/PopPopTradingCards/Images/Mickey_Mantle1952.jpg", "Red box in Attic", "Micky Mantle", "New York Yankees", 3, 1952 }
                });

            migrationBuilder.InsertData(
                table: "MagicCard",
                columns: new[] { "Id", "Booster", "CMC", "Color", "Image", "Location", "Name", "Rarity", "Type", "UserId" },
                values: new object[,]
                {
                    { 4, "Zendikar", 5, "Black", "C:/Users/ZFisher-LegionY530/Desktop/PopPopTradingCards/PopPopTradingCards/PopPopTradingCards/Images/Ob_Nixilis_the_Fallen.jpg", "", "Ob Bixilis, the Fallen", "Ultra Rare", "Legendary Creature - Demon", -1 },
                    { 2, "Zendikar", 3, "Black", "C:/Users/ZFisher-LegionY530/Desktop/PopPopTradingCards/PopPopTradingCards/PopPopTradingCards/Images/Vampire_Knighthawk_Zendikar.jfif", "", "Vampire Nighthawk", "Uncommon", "Creature - Vampire Shaman", -1 },
                    { 5, "Zendikar", 5, "Black", "C:/Users/ZFisher-LegionY530/Desktop/PopPopTradingCards/PopPopTradingCards/PopPopTradingCards/Images/Ob_Nixilis_the_Fallen.jpg", "", "Ob Bixilis, the Fallen", "Ultra Rare", "Legendary Creature - Demon", 1 },
                    { 1, "Zendikar", 3, "Black", "C:/Users/ZFisher-LegionY530/Desktop/PopPopTradingCards/PopPopTradingCards/PopPopTradingCards/Images/Vampire_Knighthawk_Zendikar.jfif", "Basement, red binder", "Vampire Nighthawk", "Uncommon", "Creature - Vampire Shaman", 1 },
                    { 3, "Zendikar", 3, "Black", "C:/Users/ZFisher-LegionY530/Desktop/PopPopTradingCards/PopPopTradingCards/PopPopTradingCards/Images/Vampire_Knighthawk_Zendikar.jfif", "Basement, red binder", "Vampire Nighthawk", "Uncommon", "Creature - Vampire Shaman", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseballCard_UserId",
                table: "BaseballCard",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCard_UserId",
                table: "MagicCard",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseballCard");

            migrationBuilder.DropTable(
                name: "MagicCard");

            migrationBuilder.DropTable(
                name: "User",
                schema: "TradingCardTracker");
        }
    }
}
