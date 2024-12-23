using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorLine.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdsSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    AdID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Jet:Identity", "1, 1"),
                    Title = table.Column<string>(type: "longchar", nullable: false),
                    Description = table.Column<string>(type: "longchar", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Condition = table.Column<string>(type: "longchar", nullable: false),
                    Category = table.Column<string>(type: "longchar", nullable: false),
                    Model = table.Column<string>(type: "longchar", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "longchar", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    FuelType = table.Column<string>(type: "longchar", nullable: false),
                    Motor = table.Column<string>(type: "longchar", nullable: false),
                    Color = table.Column<string>(type: "longchar", nullable: false),
                    Photo1 = table.Column<string>(type: "longchar", nullable: false),
                    Photo2 = table.Column<string>(type: "longchar", nullable: true),
                    Photo3 = table.Column<string>(type: "longchar", nullable: true),
                    Photo4 = table.Column<string>(type: "longchar", nullable: true),
                    Photo5 = table.Column<string>(type: "longchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.AdID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads");
        }
    }
}
