using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace soruCevapPortali.Migrations
{
    /// <inheritdoc />
    public partial class userDegistirme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_UserId1",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AspNetUsers_UserId1",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Questions",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_UserId1",
                table: "Questions",
                newName: "IX_Questions_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Answers",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_UserId1",
                table: "Answers",
                newName: "IX_Answers_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_AppUserId",
                table: "Answers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AspNetUsers_AppUserId",
                table: "Questions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_AppUserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AspNetUsers_AppUserId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Questions",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_AppUserId",
                table: "Questions",
                newName: "IX_Questions_UserId1");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Answers",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_AppUserId",
                table: "Answers",
                newName: "IX_Answers_UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_UserId1",
                table: "Answers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AspNetUsers_UserId1",
                table: "Questions",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
