namespace ApiaryDiary.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class FixTheTableRelationsBetweenApiaryAndApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Apiaries_ApiaryId1",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ApiaryId1",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ApiaryId1",
                table: "Locations");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Notes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "ApiaryId1",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ApiaryId1",
                table: "Locations",
                column: "ApiaryId1",
                unique: true,
                filter: "[ApiaryId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Apiaries_ApiaryId1",
                table: "Locations",
                column: "ApiaryId1",
                principalTable: "Apiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
