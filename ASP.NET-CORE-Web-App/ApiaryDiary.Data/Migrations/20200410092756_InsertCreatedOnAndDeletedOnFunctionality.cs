using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiaryDiary.Data.Migrations
{
    public partial class InsertCreatedOnAndDeletedOnFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Inspections");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "QueenBees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "QueenBees",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "QueenBees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "QueenBees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Notes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Locations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Locations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Inspections",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Inspections",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Beehives",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Beehives",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Beehives",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Beehives",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Apiaries",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Apiaries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Apiaries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "QueenBees");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "QueenBees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "QueenBees");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "QueenBees");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Beehives");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Beehives");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Beehives");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Beehives");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Apiaries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Apiaries");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Apiaries");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Inspections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
