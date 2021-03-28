using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Blog.Core.Infrastructure.Migrations
{
    public partial class UpdRatingsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RatingId",
                table: "AppBlogs",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppBlogsRatings",
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
                    table.PrimaryKey("PK_AppBlogsRatings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBlogs_RatingId",
                table: "AppBlogs",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBlogs_AppBlogsRatings_RatingId",
                table: "AppBlogs",
                column: "RatingId",
                principalTable: "AppBlogsRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBlogs_AppBlogsRatings_RatingId",
                table: "AppBlogs");

            migrationBuilder.DropTable(
                name: "AppBlogsRatings");

            migrationBuilder.DropIndex(
                name: "IX_AppBlogs_RatingId",
                table: "AppBlogs");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "AppBlogs");
        }
    }
}
