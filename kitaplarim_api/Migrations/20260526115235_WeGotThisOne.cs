using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kitaplarim_api.Migrations
{
    /// <inheritdoc />
    public partial class WeGotThisOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "HashedPassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "Users",
                newName: "PasswordHash");
        }
    }
}
