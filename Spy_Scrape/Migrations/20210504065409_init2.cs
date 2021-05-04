using Microsoft.EntityFrameworkCore.Migrations;

namespace Spy_Scrape.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f29de43-295d-466f-b8c6-dc5a62f9c9a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c88fd1ad-7b8d-46ea-8d02-372ae91c98e9");

            migrationBuilder.CreateTable(
                name: "TrafficeSources",
                columns: table => new
                {
                    TrafficSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficSourceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrafficeSources", x => x.TrafficSourceId);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdOs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdTargetMarket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdMarketCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrafficSourceId = table.Column<int>(type: "int", nullable: false),
                    TrafficeSourceTrafficSourceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ads_TrafficeSources_TrafficeSourceTrafficSourceId",
                        column: x => x.TrafficeSourceTrafficSourceId,
                        principalTable: "TrafficeSources",
                        principalColumn: "TrafficSourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21122c6a-c11d-4031-be59-d0d994d68e03", "2155f456-d7f3-4526-9be0-b207dc8dcfb7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "443d90af-a3c8-4219-96e1-c1764f9ef87d", "dae2df5c-dd6d-49f1-8dcf-babd03e61dee", "Customer", "Customer" });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_TrafficeSourceTrafficSourceId",
                table: "Ads",
                column: "TrafficeSourceTrafficSourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "TrafficeSources");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21122c6a-c11d-4031-be59-d0d994d68e03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "443d90af-a3c8-4219-96e1-c1764f9ef87d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c88fd1ad-7b8d-46ea-8d02-372ae91c98e9", "4097554d-5098-4467-9878-5a230117aebe", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f29de43-295d-466f-b8c6-dc5a62f9c9a2", "7e70e2c4-7f2b-4eca-a449-c3e341136f50", "Customer", "Customer" });
        }
    }
}
