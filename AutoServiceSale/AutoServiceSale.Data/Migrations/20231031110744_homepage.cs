using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoServiceSale.Data.Migrations
{
    /// <inheritdoc />
    public partial class homepage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Autos",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Autos");
        }
    }
}
