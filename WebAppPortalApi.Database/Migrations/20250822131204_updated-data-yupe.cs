using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppPortalSite.Migrations
{
    /// <inheritdoc />
    public partial class updateddatayupe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBase64",
                table: "Products");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Products",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImageBase64",
                table: "Products",
                type: "varchar(max)",
                nullable: true);
        }
    }
}
