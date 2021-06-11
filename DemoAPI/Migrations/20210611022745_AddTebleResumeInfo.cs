using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoAPI.Migrations
{
    public partial class AddTebleResumeInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_document_users_UserId",
                table: "document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_document",
                table: "document");

            migrationBuilder.RenameTable(
                name: "document",
                newName: "documents");

            migrationBuilder.RenameIndex(
                name: "IX_document_UserId",
                table: "documents",
                newName: "IX_documents_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_documents",
                table: "documents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "resumeInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    LinkIn = table.Column<string>(type: "TEXT", nullable: true),
                    Twitter = table.Column<string>(type: "TEXT", nullable: true),
                    Blog = table.Column<string>(type: "TEXT", nullable: true),
                    Portfolio = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_at = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resumeInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resumeInfos_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_resumeInfos_UserId",
                table: "resumeInfos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_documents_users_UserId",
                table: "documents",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_documents_users_UserId",
                table: "documents");

            migrationBuilder.DropTable(
                name: "resumeInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_documents",
                table: "documents");

            migrationBuilder.RenameTable(
                name: "documents",
                newName: "document");

            migrationBuilder.RenameIndex(
                name: "IX_documents_UserId",
                table: "document",
                newName: "IX_document_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_document",
                table: "document",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_document_users_UserId",
                table: "document",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
