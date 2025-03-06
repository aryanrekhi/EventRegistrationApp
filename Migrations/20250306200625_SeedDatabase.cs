using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventRegistration.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdditionalRequest", "DateRegistered", "Email", "Gender", "Name", "SelectedDays" },
                values: new object[,]
                {
                    { 1, "Vegetarian meal", new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", "F", "Alice Johnson", "Day 1, Day 3" },
                    { 2, "Need wheelchair access", new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@example.com", "M", "Bob Smith", "Day 2" },
                    { 3, "No special request", new DateTime(2019, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie@example.com", "M", "Charlie Brown", "Day 1, Day 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
