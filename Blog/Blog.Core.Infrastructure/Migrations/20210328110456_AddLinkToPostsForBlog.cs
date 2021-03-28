using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Blog.Core.Infrastructure.Migrations
{
    public partial class AddLinkToPostsForBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppPosts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorUserId = table.Column<string>(type: "text", nullable: true),
                    RatingId = table.Column<long>(type: "bigint", nullable: false),
                    BlogEntityId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPosts_AppBlogs_BlogEntityId",
                        column: x => x.BlogEntityId,
                        principalTable: "AppBlogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPosts_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppComments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ParentCommentId = table.Column<long>(type: "bigint", nullable: false),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppComments_AppPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "AppPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppPostTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatorUserId = table.Column<string>(type: "text", nullable: true),
                    PostId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPostTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPostTags_AppPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "AppPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppComments_PostId",
                table: "AppComments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_AppComments_UserId",
                table: "AppComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPosts_BlogEntityId",
                table: "AppPosts",
                column: "BlogEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPosts_CreatorUserId",
                table: "AppPosts",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPostTags_PostId",
                table: "AppPostTags",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppComments");

            migrationBuilder.DropTable(
                name: "AppPostTags");

            migrationBuilder.DropTable(
                name: "AppPosts");
        }
    }
}
