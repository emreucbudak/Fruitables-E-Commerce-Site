using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitablesAPI.Migrations
{
    /// <inheritdoc />
    public partial class Salesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "WeGives");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "WeGives",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "WeGives");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WeGives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
