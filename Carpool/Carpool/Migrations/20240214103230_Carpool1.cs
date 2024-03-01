using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpool.Migrations
{
    public partial class Carpool1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "OfferRide",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "OfferRide",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Time",
                table: "OfferRide",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "OfferRide",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

          
        }
    }
}
