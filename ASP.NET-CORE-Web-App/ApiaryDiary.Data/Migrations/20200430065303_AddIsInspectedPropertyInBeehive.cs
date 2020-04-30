using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiaryDiary.Data.Migrations
{
    public partial class AddIsInspectedPropertyInBeehive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInspected",
                table: "Beehives",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInspected",
                table: "Beehives");
        }
    }
}
