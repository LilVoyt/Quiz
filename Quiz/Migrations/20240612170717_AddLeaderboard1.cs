using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaderboard1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaderboard_Users_UserId",
                table: "Leaderboard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leaderboard",
                table: "Leaderboard");

            migrationBuilder.RenameTable(
                name: "Leaderboard",
                newName: "Leaders");

            migrationBuilder.RenameIndex(
                name: "IX_Leaderboard_UserId",
                table: "Leaders",
                newName: "IX_Leaders_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Leaders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leaders",
                table: "Leaders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leaders_Users_UserId",
                table: "Leaders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaders_Users_UserId",
                table: "Leaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leaders",
                table: "Leaders");

            migrationBuilder.RenameTable(
                name: "Leaders",
                newName: "Leaderboard");

            migrationBuilder.RenameIndex(
                name: "IX_Leaders_UserId",
                table: "Leaderboard",
                newName: "IX_Leaderboard_UserId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Leaderboard",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leaderboard",
                table: "Leaderboard",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leaderboard_Users_UserId",
                table: "Leaderboard",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
