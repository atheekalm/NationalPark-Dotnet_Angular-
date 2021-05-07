using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotnet_WebAPI.Data.Migrations
{
    public partial class addingpictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Pictures",
                table: "Yala",
                type: "BLOB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pictures",
                table: "Yala");
        }
    }
}
