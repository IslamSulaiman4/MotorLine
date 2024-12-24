using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorLine.Migrations
{
    public partial class ChangeTitleToUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Ads",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longchar");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_Title",
                table: "Ads",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ads_Title",
                table: "Ads");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Ads",
                type: "longchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }
    }
}
