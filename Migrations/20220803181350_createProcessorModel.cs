using Microsoft.EntityFrameworkCore.Migrations;

namespace p127Api.Migrations
{
    public partial class createProcessorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessorId",
                table: "Phones",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    GHz = table.Column<int>(nullable: false),
                    Cores = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ProcessorId",
                table: "Phones",
                column: "ProcessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Processors_ProcessorId",
                table: "Phones",
                column: "ProcessorId",
                principalTable: "Processors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Processors_ProcessorId",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropIndex(
                name: "IX_Phones_ProcessorId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ProcessorId",
                table: "Phones");
        }
    }
}
