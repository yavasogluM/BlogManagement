using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogManagement.Data.Migrations
{
    public partial class AuthorCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEntities");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "ArticleEntities");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "ArticleEntities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuthorEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    AuthorName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorEntities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleEntities_AuthorId",
                table: "ArticleEntities",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleEntities_AuthorEntities_AuthorId",
                table: "ArticleEntities",
                column: "AuthorId",
                principalTable: "AuthorEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleEntities_AuthorEntities_AuthorId",
                table: "ArticleEntities");

            migrationBuilder.DropTable(
                name: "AuthorEntities");

            migrationBuilder.DropIndex(
                name: "IX_ArticleEntities_AuthorId",
                table: "ArticleEntities");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "ArticleEntities");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "ArticleEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntities", x => x.Id);
                });
        }
    }
}
