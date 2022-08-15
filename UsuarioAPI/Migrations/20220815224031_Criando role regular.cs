using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuarioAPI.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "9cccfad6-133a-42cc-a56b-6dfc93a488af");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "318f97d9-54f2-4421-b0f4-a97815f0e29d", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d246ecf1-a0cb-48a8-a138-27a458057d53", "AQAAAAEAACcQAAAAEMkLDTU8IvhLzjZHNdv6BM+voBX+oyj0pYGZoyYbYQLPGktGicL+YV7NypqEsc9rqA==", "e804221b-6480-4168-af42-40e52f07d538" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "2a331818-58e8-43e1-9691-53a8ec937eec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "037048fe-a3a2-4b81-8219-0a9e2873607b", "AQAAAAEAACcQAAAAEDtJo3e0IncuFXb0vv/b2ZiI5yk+o0tzeL033Nk+ps1n3sSB9VdCUoSuEdX775fD6g==", "982b1407-6cec-4d87-8f39-f89ae49a3b57" });
        }
    }
}
