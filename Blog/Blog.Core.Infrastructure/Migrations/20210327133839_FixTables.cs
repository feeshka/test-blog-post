using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Core.Infrastructure.Migrations
{
    public partial class FixTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBlogs_AspNetUsers_UserId1",
                table: "AppBlogs");

            migrationBuilder.DropIndex(
                name: "IX_AppBlogs_UserId1",
                table: "AppBlogs");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "AppBlogs",
                newName: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorUserId",
                table: "AppBlogTags",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AppBlogs",
                type: "text",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_AppBlogs_UserId",
                table: "AppBlogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBlogs_AspNetUsers_UserId",
                table: "AppBlogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBlogs_AspNetUsers_UserId",
                table: "AppBlogs");

            migrationBuilder.DropIndex(
                name: "IX_AppBlogs_UserId",
                table: "AppBlogs");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "AppBlogs",
                newName: "UserId1");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorUserId",
                table: "AppBlogTags",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "AppBlogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppBlogs_UserId1",
                table: "AppBlogs",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBlogs_AspNetUsers_UserId1",
                table: "AppBlogs",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
