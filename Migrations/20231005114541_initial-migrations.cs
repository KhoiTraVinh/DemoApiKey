using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiKey.Migrations
{
    /// <inheritdoc />
    public partial class initialmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiKey",
                columns: table => new
                {
                    KeyId = table.Column<string>(type: "nvarchar", maxLength: 128, nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Permissions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKey", x => x.KeyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiKey");
        }
    }
}
