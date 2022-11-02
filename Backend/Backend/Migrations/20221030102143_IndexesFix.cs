using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class IndexesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Animals_SpecieId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_UserId",
                table: "Animals");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpecieId",
                table: "Animals",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserId",
                table: "Animals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Animals_SpecieId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_UserId",
                table: "Animals");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpecieId",
                table: "Animals",
                column: "SpecieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserId",
                table: "Animals",
                column: "UserId",
                unique: true);
        }
    }
}
