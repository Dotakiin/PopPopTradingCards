using Microsoft.EntityFrameworkCore.Migrations;

namespace PopPopTradingCardsLib.Migrations
{
    public partial class CodeFirst : Migration
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
                name: "BaseballCards",
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
                    table.PrimaryKey("PK_BaseballCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseballCards_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "TradingCardTracker",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagicCards",
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
                    table.PrimaryKey("PK_MagicCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicCards_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "TradingCardTracker",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseballCards_UserId",
                table: "BaseballCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCards_UserId",
                table: "MagicCards",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseballCards");

            migrationBuilder.DropTable(
                name: "MagicCards");

            migrationBuilder.DropTable(
                name: "User",
                schema: "TradingCardTracker");
        }
    }
}
