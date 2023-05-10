using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_App.Data.Migrations
{
    public partial class initialsetup11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndingTime",
                table: "TaskToDo",
                type: "dateTime",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingTime",
                table: "TaskToDo",
                type: "dateTime",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndingTime",
                table: "TaskToDo");

            migrationBuilder.DropColumn(
                name: "StartingTime",
                table: "TaskToDo");
        }
    }
}
