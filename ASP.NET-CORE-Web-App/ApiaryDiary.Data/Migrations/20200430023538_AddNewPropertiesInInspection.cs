namespace ApiaryDiary.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddNewPropertiesInInspection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HiveCondition",
                table: "Inspections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HygieneLevel",
                table: "Inspections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HiveCondition",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "HygieneLevel",
                table: "Inspections");
        }
    }
}
