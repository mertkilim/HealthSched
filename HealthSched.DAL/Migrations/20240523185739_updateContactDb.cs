using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthSched.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateContactDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isOkay",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isOkay",
                table: "Contacts");
        }
    }
}
