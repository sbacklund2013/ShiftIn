using Microsoft.EntityFrameworkCore.Migrations;

namespace Shiftin.Migrations
{
    public partial class relationship_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UserId1",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Likes",
                newName: "ApplicationUserId1");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Likes",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId1",
                table: "Likes",
                newName: "IX_Likes_ApplicationUserId1");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId1",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatorId1",
                table: "Events",
                column: "CreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_CreatorId1",
                table: "Events",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_ApplicationUserId1",
                table: "Likes",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_CreatorId1",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_ApplicationUserId1",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Events_CreatorId1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId1",
                table: "Likes",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Likes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_ApplicationUserId1",
                table: "Likes",
                newName: "IX_Likes_UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UserId1",
                table: "Likes",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
