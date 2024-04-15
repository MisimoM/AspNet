using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddressColumnUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetLine_2",
                table: "Address",
                newName: "AddressLine_2");

            migrationBuilder.RenameColumn(
                name: "StreetLine_1",
                table: "Address",
                newName: "AddressLine_1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressLine_2",
                table: "Address",
                newName: "StreetLine_2");

            migrationBuilder.RenameColumn(
                name: "AddressLine_1",
                table: "Address",
                newName: "StreetLine_1");
        }
    }
}
