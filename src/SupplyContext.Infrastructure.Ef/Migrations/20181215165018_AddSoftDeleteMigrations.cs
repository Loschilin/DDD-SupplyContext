using Microsoft.EntityFrameworkCore.Migrations;

namespace SupplyContext.Infrastructure.Ef.Migrations
{
    public partial class AddSoftDeleteMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_SupplyLists_ListId",
                schema: "dbo",
                table: "Supplies");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "dbo",
                table: "Supplies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_SupplyLists_ListId",
                schema: "dbo",
                table: "Supplies",
                column: "ListId",
                principalSchema: "dbo",
                principalTable: "SupplyLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_SupplyLists_ListId",
                schema: "dbo",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "dbo",
                table: "Supplies");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_SupplyLists_ListId",
                schema: "dbo",
                table: "Supplies",
                column: "ListId",
                principalSchema: "dbo",
                principalTable: "SupplyLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
