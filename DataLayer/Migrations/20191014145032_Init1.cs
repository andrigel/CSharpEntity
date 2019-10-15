using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    TicketNumber = table.Column<int>(nullable: false),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_book_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReaderId = table.Column<int>(nullable: true),
                    BookId = table.Column<int>(nullable: true),
                    DateOfIssue = table.Column<DateTime>(nullable: false),
                    DateOfReturn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_log_book_BookId",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_log_reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "reader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_AuthorId",
                table: "book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_log_BookId",
                table: "log",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_log_ReaderId",
                table: "log",
                column: "ReaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "log");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "reader");

            migrationBuilder.DropTable(
                name: "author");
        }
    }
}
