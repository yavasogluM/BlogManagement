using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogManagement.Data.Migrations
{
    public partial class ArticleComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "CommentEntities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentEntities_ArticleId",
                table: "CommentEntities",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentEntities_ArticleEntities_ArticleId",
                table: "CommentEntities",
                column: "ArticleId",
                principalTable: "ArticleEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentEntities_ArticleEntities_ArticleId",
                table: "CommentEntities");

            migrationBuilder.DropIndex(
                name: "IX_CommentEntities_ArticleId",
                table: "CommentEntities");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "CommentEntities");
        }
    }
}
