using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaghettiCommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");
        }
    }
}
