using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Chilli.Infrastructure.Migrations
{
    public partial class AddsImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MediaId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MediaEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_MediaId",
                table: "Products",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MediaEntity_MediaId",
                table: "Products",
                column: "MediaId",
                principalTable: "MediaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MediaEntity_MediaId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "MediaEntity");

            migrationBuilder.DropIndex(
                name: "IX_Products_MediaId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Products");
        }
    }
}
