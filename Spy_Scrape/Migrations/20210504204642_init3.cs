using Microsoft.EntityFrameworkCore.Migrations;

namespace Spy_Scrape.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "86815b3d-c69d-4bea-99c1-253f6d0fe403", "7b42648d-1269-4d72-8bb7-d55b66a0e457", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8f1a69a-6c76-42c2-96e0-02309c74caed", "8575cde8-49d2-4985-b603-6504bc7430b2", "Customer", "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86815b3d-c69d-4bea-99c1-253f6d0fe403");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8f1a69a-6c76-42c2-96e0-02309c74caed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21122c6a-c11d-4031-be59-d0d994d68e03", "2155f456-d7f3-4526-9be0-b207dc8dcfb7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "443d90af-a3c8-4219-96e1-c1764f9ef87d", "dae2df5c-dd6d-49f1-8dcf-babd03e61dee", "Customer", "Customer" });
        }
    }
}
