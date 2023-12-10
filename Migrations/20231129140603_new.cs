using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyLibrary.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    LibraryAddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CopiesInLibrary = table.Column<int>(type: "int", nullable: false),
                    CopiesOutLibrary = table.Column<int>(type: "int", nullable: false),
                    AvailableCopies = table.Column<int>(type: "int", nullable: false),
                    EVersion = table.Column<bool>(type: "bit", nullable: false),
                    bookcategories = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, null, "Drama", null },
                    { 2, null, null, "Horror", null },
                    { 3, null, null, "Mystery", null },
                    { 4, null, null, "Sci_Fi", null },
                    { 5, null, null, "Art", null },
                    { 6, null, null, "Biography", null },
                    { 7, null, null, "Sport", null },
                    { 8, null, null, "Travel", null },
                    { 9, null, null, "Blues", null },
                    { 10, null, null, "Classic", null },
                    { 11, null, null, "Folk", null },
                    { 12, null, null, "Hip_Hop", null },
                    { 13, null, null, "Rap", null },
                    { 14, null, null, "Reggae", null },
                    { 15, null, null, " Rock", null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableCopies", "CopiesInLibrary", "CopiesOutLibrary", "CreatedAt", "DeletedAt", "Description", "EVersion", "GenreId", "ISBN", "ImageURL", "Language", "LibraryAddDate", "Pages", "Publisher", "Title", "UpdatedAt", "bookcategories" },
                values: new object[] { 1, "J.K Rowling", 47, 50, 3, new DateTime(2023, 11, 29, 15, 6, 3, 180, DateTimeKind.Local).AddTicks(5091), null, "Magic", true, 1, "975609876112", "images/Fiction/drama/download.jpeg", "English", new DateTime(2023, 11, 29, 15, 6, 3, 180, DateTimeKind.Local).AddTicks(5075), 780, "Bloomsbury", "Harry Potter and the Prisoner of Azkaban", new DateTime(2023, 11, 29, 15, 6, 3, 180, DateTimeKind.Local).AddTicks(5095), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
