using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BC.Bicycles.Migrations
{
    public partial class ChangeUsernameToEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Bicycles",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Bicycles",
                newName: "UserName");
        }
    }
}
