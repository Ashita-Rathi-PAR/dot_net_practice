using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApplication.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Class",
                table: "Student",
                type: "int(1, 12)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "Class",
                table: "Student",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(1, 12)");
        }
    }
}
