using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace soruCevapPortali.Migrations
{
    /// <inheritdoc />
    public partial class nullableQuestionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_SorularQuestionId",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "SorularQuestionId",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_SorularQuestionId",
                table: "Answers",
                column: "SorularQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_SorularQuestionId",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "SorularQuestionId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_SorularQuestionId",
                table: "Answers",
                column: "SorularQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
