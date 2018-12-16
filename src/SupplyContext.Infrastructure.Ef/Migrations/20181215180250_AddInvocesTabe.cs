using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupplyContext.Infrastructure.Ef.Migrations
{
    public partial class AddInvocesTabe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoces",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplyNumber = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Goods = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoces", x => x.Id);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoceList");

            migrationBuilder.DropTable(
                name: "Invoces",
                schema: "dbo");
        }
    }
}
