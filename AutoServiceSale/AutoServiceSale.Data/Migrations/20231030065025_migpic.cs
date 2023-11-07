using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoServiceSale.Data.Migrations
{
    /// <inheritdoc />
    public partial class migpic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture1URL",
                table: "Autos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture2URL",
                table: "Autos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture3URL",
                table: "Autos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture1URL",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "Picture2URL",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "Picture3URL",
                table: "Autos");
        }
    }
}
