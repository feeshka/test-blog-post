using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Blog.Core.Infrastructure.Migrations
{
    public partial class LinkToPostRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RatingId",
                table: "AppPosts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "AppPostsRatings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsersCount = table.Column<int>(type: "integer", nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPostsRatings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppPosts_RatingId",
                table: "AppPosts",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPosts_AppPostsRatings_RatingId",
                table: "AppPosts",
                column: "RatingId",
                principalTable: "AppPostsRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPosts_AppPostsRatings_RatingId",
                table: "AppPosts");

            migrationBuilder.DropTable(
                name: "AppPostsRatings");

            migrationBuilder.DropIndex(
                name: "IX_AppPosts_RatingId",
                table: "AppPosts");

            migrationBuilder.AlterColumn<long>(
                name: "RatingId",
                table: "AppPosts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
