using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppPortalSite.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "log");

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogLevel = table.Column<string>(type: "varchar(80)", nullable: false),
                    State = table.Column<string>(type: "varchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "varchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "varchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                schema: "log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "varchar(2048)", nullable: false),
                    HttpStatusCode = table.Column<string>(type: "varchar(80)", nullable: false),
                    HttpMethod = table.Column<string>(type: "varchar(80)", nullable: false),
                    RequestBody = table.Column<string>(type: "varchar(max)", nullable: false),
                    ResponseBody = table.Column<string>(type: "varchar(max)", nullable: false),
                    RequestHeaders = table.Column<string>(type: "varchar(max)", nullable: false),
                    ResponseHeaders = table.Column<string>(type: "varchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeTaken = table.Column<TimeSpan>(type: "time", nullable: true),
                    Archived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "varchar(254)", nullable: false),
                    Password = table.Column<string>(type: "varchar(2000)", nullable: false),
                    Salt = table.Column<string>(type: "varchar(500)", nullable: false),
                    FirstNames = table.Column<string>(type: "varchar(300)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(300)", nullable: false),
                    Role = table.Column<string>(type: "varchar(80)", nullable: false),
                    RegistrationStatus = table.Column<string>(type: "varchar(80)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastSignIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events",
                schema: "log");

            migrationBuilder.DropTable(
                name: "Requests",
                schema: "log");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
