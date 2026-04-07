using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EjemploPosgres.Migrations
{
    /// <inheritdoc />
    public partial class telefono_persona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Personas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Personas");
        }
    }
}
