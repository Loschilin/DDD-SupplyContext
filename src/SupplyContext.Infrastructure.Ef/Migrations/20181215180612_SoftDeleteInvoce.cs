using Microsoft.EntityFrameworkCore.Migrations;

namespace SupplyContext.Infrastructure.Ef.Migrations
{
    public partial class SoftDeleteInvoce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "dbo",
                table: "Invoces",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "dbo",
                table: "Invoces");
        }
    }
}
