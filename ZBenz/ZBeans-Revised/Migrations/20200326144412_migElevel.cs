using Microsoft.EntityFrameworkCore.Migrations;

namespace ZBeans_Revised.Migrations
{
    public partial class migElevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Elevel",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elevel",
                table: "AspNetUsers");
        }
    }
}
