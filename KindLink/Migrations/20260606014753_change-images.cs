using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindLink.Migrations
{
    /// <inheritdoc />
    public partial class changeimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Organization");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "VolunteerPosition",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "VolunteerPosition");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Organization",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
