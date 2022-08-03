using Microsoft.EntityFrameworkCore.Migrations;

namespace p127Api.Migrations
{
    public partial class addProcessorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "GHz",
                table: "Processors",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GHz",
                table: "Processors",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
