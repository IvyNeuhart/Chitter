using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chitter.Migrations
{
    /// <inheritdoc />
    public partial class thirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChitPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChitPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChitPostComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChitPostId = table.Column<int>(type: "int", nullable: false),
                    ParentCommentId = table.Column<int>(type: "int", nullable: false),
                    ChitPostCommentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitPostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChitPostComments_ChitPostComments_ChitPostCommentId",
                        column: x => x.ChitPostCommentId,
                        principalTable: "ChitPostComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChitPostComments_ChitPosts_ChitPostId",
                        column: x => x.ChitPostId,
                        principalTable: "ChitPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChitPostComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChitPostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostLikes_ChitPosts_ChitPostId",
                        column: x => x.ChitPostId,
                        principalTable: "ChitPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentLike",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChitPostCommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLike_ChitPostComments_ChitPostCommentId",
                        column: x => x.ChitPostCommentId,
                        principalTable: "ChitPostComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChitPostComments_ChitPostCommentId",
                table: "ChitPostComments",
                column: "ChitPostCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitPostComments_ChitPostId",
                table: "ChitPostComments",
                column: "ChitPostId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitPostComments_UserId",
                table: "ChitPostComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitPosts_UserId",
                table: "ChitPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLike_ChitPostCommentId",
                table: "CommentLike",
                column: "ChitPostCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_ChitPostId",
                table: "PostLikes",
                column: "ChitPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentLike");

            migrationBuilder.DropTable(
                name: "PostLikes");

            migrationBuilder.DropTable(
                name: "ChitPostComments");

            migrationBuilder.DropTable(
                name: "ChitPosts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
