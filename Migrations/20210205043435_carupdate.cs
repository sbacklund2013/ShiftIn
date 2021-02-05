using Microsoft.EntityFrameworkCore.Migrations;

namespace Shiftin.Migrations
{
    public partial class carupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Car",
                newName: "Make");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Make",
                table: "Car",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
