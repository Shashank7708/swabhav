using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactAndAddressApp_data.Migrations
{
    public partial class addingfavouritev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Favourite",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favourite",
                table: "User");
        }
    }
}
