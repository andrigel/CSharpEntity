using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_author_AuthorId",
                table: "book");

            migrationBuilder.DropForeignKey(
                name: "FK_log_book_BookId",
                table: "log");

            migrationBuilder.DropForeignKey(
                name: "FK_log_reader_ReaderId",
                table: "log");

            migrationBuilder.AddForeignKey(
                name: "FK_book_author_AuthorId",
                table: "book",
                column: "AuthorId",
                principalTable: "author",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_log_book_BookId",
                table: "log",
                column: "BookId",
                principalTable: "book",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_log_reader_ReaderId",
                table: "log",
                column: "ReaderId",
                principalTable: "reader",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_author_AuthorId",
                table: "book");

            migrationBuilder.DropForeignKey(
                name: "FK_log_book_BookId",
                table: "log");

            migrationBuilder.DropForeignKey(
                name: "FK_log_reader_ReaderId",
                table: "log");

            migrationBuilder.AddForeignKey(
                name: "FK_book_author_AuthorId",
                table: "book",
                column: "AuthorId",
                principalTable: "author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_log_book_BookId",
                table: "log",
                column: "BookId",
                principalTable: "book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_log_reader_ReaderId",
                table: "log",
                column: "ReaderId",
                principalTable: "reader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
