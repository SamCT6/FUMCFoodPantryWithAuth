using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FUMCFoodPantry.Data.Migrations
{
    /// <inheritdoc />
    public partial class orderupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderForm",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderForm");
        }
    }
}
