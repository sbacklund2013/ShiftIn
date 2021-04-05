using Microsoft.EntityFrameworkCore.Migrations;

namespace Shiftin.Migrations
{
    public partial class authoredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Profiles_AuthorId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Posts",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Profiles_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Profiles_AuthorId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Profiles_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
