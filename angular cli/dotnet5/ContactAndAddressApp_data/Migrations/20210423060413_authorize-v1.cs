using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactAndAddressApp_data.Migrations
{
    public partial class authorizev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Contact_contactId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "mobileno",
                table: "Contact",
                newName: "Mobileno");

            migrationBuilder.RenameColumn(
                name: "contactId",
                table: "Address",
                newName: "ContactId");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Address",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_Address_contactId",
                table: "Address",
                newName: "IX_Address_ContactId");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tenent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Contact_ContactId",
                table: "Address",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Contact_ContactId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tenent");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Mobileno",
                table: "Contact",
                newName: "mobileno");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Address",
                newName: "contactId");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Address",
                newName: "city");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ContactId",
                table: "Address",
                newName: "IX_Address_contactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Contact_contactId",
                table: "Address",
                column: "contactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
