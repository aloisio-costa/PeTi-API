using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeTiAPI.Migrations
{
    public partial class AddRelationalPetSitterReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PetSitterId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_PetSitters_PetSitterId",
                table: "Reviews",
                column: "PetSitterId",
                principalTable: "PetSitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_PetSitters_PetSitterId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "PetSitterId",
                table: "Reviews");
        }
    }
}
