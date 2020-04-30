using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiaryDiary.Data.Migrations
{
    public partial class AddIsInspectedPropertyInInspections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInspected",
                table: "Inspections",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInspected",
                table: "Inspections");
        }
    }
}
