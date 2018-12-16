using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupplyContext.Infrastructure.Ef.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "SupplyLists",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BarCode = table.Column<string>(nullable: false),
                    FileKey = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ContractorCode = table.Column<string>(nullable: true),
                    ListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplies_SupplyLists_ListId",
                        column: x => x.ListId,
                        principalSchema: "dbo",
                        principalTable: "SupplyLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_ListId",
                schema: "dbo",
                table: "Supplies",
                column: "ListId",
                unique: true,
                filter: "[ListId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_Number",
                schema: "dbo",
                table: "Supplies",
                column: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SupplyLists",
                schema: "dbo");
        }
    }
}
