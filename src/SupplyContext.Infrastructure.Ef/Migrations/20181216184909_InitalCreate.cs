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
                name: "Invoces",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplyNumber = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Goods = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoces", x => x.Id);
                });

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
                name: "InvoceList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BarCode = table.Column<string>(nullable: false),
                    FileKey = table.Column<string>(nullable: false),
                    InvoceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoceList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoceList_Invoces_InvoceId",
                        column: x => x.InvoceId,
                        principalSchema: "dbo",
                        principalTable: "Invoces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TitleListId = table.Column<int>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplies_SupplyLists_TitleListId",
                        column: x => x.TitleListId,
                        principalSchema: "dbo",
                        principalTable: "SupplyLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoceList_InvoceId",
                table: "InvoceList",
                column: "InvoceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoces_Number",
                schema: "dbo",
                table: "Invoces",
                column: "Number",
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoces_SupplyNumber",
                schema: "dbo",
                table: "Invoces",
                column: "SupplyNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_Number",
                schema: "dbo",
                table: "Supplies",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_TitleListId",
                schema: "dbo",
                table: "Supplies",
                column: "TitleListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoceList");

            migrationBuilder.DropTable(
                name: "Supplies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Invoces",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SupplyLists",
                schema: "dbo");
        }
    }
}
