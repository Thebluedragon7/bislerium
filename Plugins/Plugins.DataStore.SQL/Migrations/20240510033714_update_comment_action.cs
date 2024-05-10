using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class update_comment_action : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentActions_AspNetUsers_ActionBy",
                table: "CommentActions");

            migrationBuilder.DropIndex(
                name: "IX_CommentActions_ActionBy",
                table: "CommentActions");

            migrationBuilder.DropColumn(
                name: "ActionBy",
                table: "CommentActions");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CommentActions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentActions_UserId",
                table: "CommentActions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentActions_AspNetUsers_UserId",
                table: "CommentActions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentActions_AspNetUsers_UserId",
                table: "CommentActions");

            migrationBuilder.DropIndex(
                name: "IX_CommentActions_UserId",
                table: "CommentActions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CommentActions");

            migrationBuilder.AddColumn<string>(
                name: "ActionBy",
                table: "CommentActions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CommentActions_ActionBy",
                table: "CommentActions",
                column: "ActionBy");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentActions_AspNetUsers_ActionBy",
                table: "CommentActions",
                column: "ActionBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
