using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpSoluctions.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressMd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Additional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressMd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryMd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client_Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AndressIdId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FederalRegistration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateRegistration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Company_AddressMd_AndressIdId",
                        column: x => x.AndressIdId,
                        principalTable: "AddressMd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client_Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AndressIdId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Person_AddressMd_AndressIdId",
                        column: x => x.AndressIdId,
                        principalTable: "AddressMd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publishing_Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AndressIdId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FederalRegistration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateRegistration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishing_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publishing_Company_AddressMd_AndressIdId",
                        column: x => x.AndressIdId,
                        principalTable: "AddressMd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryIdId = table.Column<int>(type: "int", nullable: false),
                    AuthorIdId = table.Column<int>(type: "int", nullable: false),
                    PublishingCompanyIdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorIdId",
                        column: x => x.AuthorIdId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_CategoryMd_CategoryIdId",
                        column: x => x.CategoryIdId,
                        principalTable: "CategoryMd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Publishing_Company_PublishingCompanyIdId",
                        column: x => x.PublishingCompanyIdId,
                        principalTable: "Publishing_Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorIdId",
                table: "Book",
                column: "AuthorIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryIdId",
                table: "Book",
                column: "CategoryIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublishingCompanyIdId",
                table: "Book",
                column: "PublishingCompanyIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Company_AndressIdId",
                table: "Client_Company",
                column: "AndressIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Person_AndressIdId",
                table: "Client_Person",
                column: "AndressIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishing_Company_AndressIdId",
                table: "Publishing_Company",
                column: "AndressIdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Client_Company");

            migrationBuilder.DropTable(
                name: "Client_Person");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "CategoryMd");

            migrationBuilder.DropTable(
                name: "Publishing_Company");

            migrationBuilder.DropTable(
                name: "AddressMd");
        }
    }
}
