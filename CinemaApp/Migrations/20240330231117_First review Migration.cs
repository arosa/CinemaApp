using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class FirstreviewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpenHours",
                table: "Theaters",
                newName: "OpenHoursTo");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "OpenHoursFrom",
                table: "Theaters",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenHoursFrom",
                table: "Theaters");

            migrationBuilder.RenameColumn(
                name: "OpenHoursTo",
                table: "Theaters",
                newName: "OpenHours");
        }
    }
}
