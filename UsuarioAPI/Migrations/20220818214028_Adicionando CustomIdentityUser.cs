using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuarioAPI.Migrations
{
    public partial class AdicionandoCustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "5039cb4a-7c95-4397-98b7-225e41dbd444");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "926cd814-3455-44c8-ad6e-d3c0dd17d8de");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c323400-f621-4c30-8b6c-a1e617ccbc66", "AQAAAAEAACcQAAAAEDi4Re8hPDuB/w6DalJphJy1xHCFdp96HIERqN57imMndGctNggOfgsa+AVEx4BVLQ==", "401b9830-ca1a-4adc-9ac4-567b6fb01319" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "318f97d9-54f2-4421-b0f4-a97815f0e29d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "9cccfad6-133a-42cc-a56b-6dfc93a488af");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d246ecf1-a0cb-48a8-a138-27a458057d53", "AQAAAAEAACcQAAAAEMkLDTU8IvhLzjZHNdv6BM+voBX+oyj0pYGZoyYbYQLPGktGicL+YV7NypqEsc9rqA==", "e804221b-6480-4168-af42-40e52f07d538" });
        }
    }
}
