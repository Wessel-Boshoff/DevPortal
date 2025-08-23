using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppPortalSite.Migrations
{
    /// <inheritdoc />
    public partial class addedexctensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageBase64",
                table: "Products",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Products",
                type: "varchar(35)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ImageBase64",
                table: "Products",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);
        }
    }
}
