using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chitter.Migrations
{
    /// <inheritdoc />
    public partial class fourthcreatye : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLike_ChitPostComments_ChitPostCommentId",
                table: "CommentLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentLike",
                table: "CommentLike");

            migrationBuilder.RenameTable(
                name: "CommentLike",
                newName: "CommentLikes");

            migrationBuilder.RenameIndex(
                name: "IX_CommentLike_ChitPostCommentId",
                table: "CommentLikes",
                newName: "IX_CommentLikes_ChitPostCommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentLikes",
                table: "CommentLikes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_ChitPostComments_ChitPostCommentId",
                table: "CommentLikes",
                column: "ChitPostCommentId",
                principalTable: "ChitPostComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_ChitPostComments_ChitPostCommentId",
                table: "CommentLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentLikes",
                table: "CommentLikes");

            migrationBuilder.RenameTable(
                name: "CommentLikes",
                newName: "CommentLike");

            migrationBuilder.RenameIndex(
                name: "IX_CommentLikes_ChitPostCommentId",
                table: "CommentLike",
                newName: "IX_CommentLike_ChitPostCommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentLike",
                table: "CommentLike",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLike_ChitPostComments_ChitPostCommentId",
                table: "CommentLike",
                column: "ChitPostCommentId",
                principalTable: "ChitPostComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
