using Microsoft.EntityFrameworkCore.Migrations;

namespace WAD.Migrations
{
    public partial class RemovedIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Books",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Books",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                newName: "IX_Books_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                newName: "IX_Books_AuthorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryID",
                table: "Books",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryID",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Books",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Books",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryID",
                table: "Books",
                newName: "IX_Books_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Authors",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
