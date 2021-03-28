using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Core.Infrastructure.Migrations
{
    public partial class AddLinktoBlogsInPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPosts_AppBlogs_BlogEntityId",
                table: "AppPosts");

            migrationBuilder.DropIndex(
                name: "IX_AppPosts_BlogEntityId",
                table: "AppPosts");

            migrationBuilder.DropColumn(
                name: "BlogEntityId",
                table: "AppPosts");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "AppPosts",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPosts_BlogId",
                table: "AppPosts",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPosts_AppBlogs_BlogId",
                table: "AppPosts",
                column: "BlogId",
                principalTable: "AppBlogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPosts_AppBlogs_BlogId",
                table: "AppPosts");

            migrationBuilder.DropIndex(
                name: "IX_AppPosts_BlogId",
                table: "AppPosts");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "AppPosts");

            migrationBuilder.AddColumn<long>(
                name: "BlogEntityId",
                table: "AppPosts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPosts_BlogEntityId",
                table: "AppPosts",
                column: "BlogEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPosts_AppBlogs_BlogEntityId",
                table: "AppPosts",
                column: "BlogEntityId",
                principalTable: "AppBlogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
