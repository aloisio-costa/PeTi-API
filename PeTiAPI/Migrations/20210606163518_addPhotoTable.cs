using Microsoft.EntityFrameworkCore.Migrations;

namespace PeTiAPI.Migrations
{
    public partial class addPhotoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ServiceRequests",
                newName: "PhotoFileName");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "PetSitters",
                newName: "PhotoFileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoFileName",
                table: "ServiceRequests",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "PhotoFileName",
                table: "PetSitters",
                newName: "Images");
        }
    }
}
