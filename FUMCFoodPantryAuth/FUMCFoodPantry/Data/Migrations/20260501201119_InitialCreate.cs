using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FUMCFoodPantry.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageRating = table.Column<double>(type: "REAL", nullable: false),
                    Served = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    FixedAddress = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    Zip = table.Column<int>(type: "INTEGER", nullable: false),
                    County = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EmploymentStatus = table.Column<string>(type: "TEXT", nullable: false),
                    HosuingStatus = table.Column<string>(type: "TEXT", nullable: false),
                    PrimaryContact = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Race = table.Column<string>(type: "TEXT", nullable: false),
                    Household = table.Column<string>(type: "TEXT", nullable: false),
                    Disability = table.Column<string>(type: "TEXT", nullable: false),
                    Military = table.Column<string>(type: "TEXT", nullable: false),
                    Vetran = table.Column<string>(type: "TEXT", nullable: false),
                    Snap = table.Column<string>(type: "TEXT", nullable: false),
                    Family1Name = table.Column<string>(type: "TEXT", nullable: true),
                    Family1Birthday = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Family1Ethnicity = table.Column<string>(type: "TEXT", nullable: true),
                    Family1Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Family1Relationship = table.Column<string>(type: "TEXT", nullable: true),
                    Family1Income = table.Column<int>(type: "INTEGER", nullable: true),
                    Family2Name = table.Column<string>(type: "TEXT", nullable: true),
                    Family2Birthday = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Family2Ethnicity = table.Column<string>(type: "TEXT", nullable: true),
                    Family2Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Family2Relationship = table.Column<string>(type: "TEXT", nullable: true),
                    Family2Income = table.Column<int>(type: "INTEGER", nullable: true),
                    Family3Name = table.Column<string>(type: "TEXT", nullable: true),
                    Family3Birthday = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Family3Ethnicity = table.Column<string>(type: "TEXT", nullable: true),
                    Family3Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Family3Relationship = table.Column<string>(type: "TEXT", nullable: true),
                    Family3Income = table.Column<int>(type: "INTEGER", nullable: true),
                    Family4Name = table.Column<string>(type: "TEXT", nullable: true),
                    Family4Birthday = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Family4Ethnicity = table.Column<string>(type: "TEXT", nullable: true),
                    Family4Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Family4Relationship = table.Column<string>(type: "TEXT", nullable: true),
                    Family4Income = table.Column<int>(type: "INTEGER", nullable: true),
                    Family5Name = table.Column<string>(type: "TEXT", nullable: true),
                    Family5Birthday = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Family5Ethnicity = table.Column<string>(type: "TEXT", nullable: true),
                    Family5Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Family5Relationship = table.Column<string>(type: "TEXT", nullable: true),
                    Family5Income = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApplications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserApplications_MemberId",
                table: "UserApplications",
                column: "MemberId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserApplications");
        }
    }
}
