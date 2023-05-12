using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_App.Data.Migrations
{
    public partial class AddPartener : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "EndingTime",
            //    table: "TaskToDo");

            //migrationBuilder.DropColumn(
            //    name: "StartingTime",
            //    table: "TaskToDo");

            migrationBuilder.AddColumn<string>(
                name: "PartnerOnThis",
                table: "TaskToDo",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartnerOnThis",
                table: "TaskToDo");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndingTime",
                table: "TaskToDo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingTime",
                table: "TaskToDo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
