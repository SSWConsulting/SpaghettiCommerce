using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaghettiCommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerOrderRef",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerOrderRef",
                table: "Orders");
        }
    }
}
