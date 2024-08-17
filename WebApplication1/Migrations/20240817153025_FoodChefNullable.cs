using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class FoodChefNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foods_chefs_ChefId",
                table: "foods");

            migrationBuilder.AlterColumn<int>(
                name: "ChefId",
                table: "foods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_foods_chefs_ChefId",
                table: "foods",
                column: "ChefId",
                principalTable: "chefs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foods_chefs_ChefId",
                table: "foods");

            migrationBuilder.AlterColumn<int>(
                name: "ChefId",
                table: "foods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_foods_chefs_ChefId",
                table: "foods",
                column: "ChefId",
                principalTable: "chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
