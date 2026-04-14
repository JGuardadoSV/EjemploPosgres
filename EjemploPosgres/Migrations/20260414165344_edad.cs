using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EjemploPosgres.Migrations
{
    /// <inheritdoc />
    public partial class edad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaReserva",
                table: "Personas",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Personas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Personas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaReserva",
                table: "Personas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
