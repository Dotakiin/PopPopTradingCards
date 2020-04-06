﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PopPopTradingCardsDataAccess.Migrations
{
    public partial class Seed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "TradingCardTracker",
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "???b??^????jYh?)?x^?K?? ???? ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "TradingCardTracker",
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "Both");
        }
    }
}
