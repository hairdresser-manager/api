using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class fix_seeded_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f297d12-c986-455b-bbdb-7f696a809aaa"),
                column: "ConcurrencyStamp",
                value: "eb2bab2b-33c5-4984-a480-e34ae83a7834");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("923c4e38-537b-4aba-8261-742f5c5df9b9"),
                column: "ConcurrencyStamp",
                value: "b6d5fd5d-8bfa-4519-925c-124b3c97b6a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("93a1489d-f4f7-4b33-a755-6c816a467ad3"),
                column: "ConcurrencyStamp",
                value: "a752e685-44f9-4178-b45c-0acd8f251bc1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e867f17-dcf3-4e59-8e55-1e1660d79224", "AQAAAAEAACcQAAAAEB2xyfV89y5mgFsTwacZTd1dNPSGnVRHsYUxx9IB8M+mfUgkRSwj7XKWXrYhdlAHeQ==", "a77d8b07-de56-4b65-b3e7-4591c74b8797" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4703242-36a0-426b-81b8-0c7336606613"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fad846c1-bec9-4c69-b98b-27d53eeaac38", "AQAAAAEAACcQAAAAEJ4xbk2bVFGnk+lSLThk6qlnSPk6y0NJqLZ2QvHCgaOAp7otQpOB+c7TIvesZKzx3g==", "1a517e38-8c38-4723-815a-243bf4e6b52f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbf17ff9-151e-449b-822e-05a80274af0e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "219c9ce3-e65d-4958-a7ad-935d6e079de4", "AQAAAAEAACcQAAAAEOsHZxhgRcEp3k+bF4bwWVyN5WnKKoMTCyYLMRhwPZFzgKx/0C4C0W/YeBfXEC3w8A==", "f8e904a2-0199-4881-ab45-28624853e226" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efac4210-d6f1-471d-91df-7c17dc81318d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcded832-35a6-4c54-8fea-2c4165f2c516", "AQAAAAEAACcQAAAAEN+myfpJj+mkVZ28edChxzw5+CMydEpvdVqf81y/NvV7wxz/I+2ySXGmnkGrB58rMQ==", "800c4c3d-22e8-4bbe-9d17-6fdf9efa911c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f297d12-c986-455b-bbdb-7f696a809aaa"),
                column: "ConcurrencyStamp",
                value: "c96363b2-6967-4b1b-9c1b-2768da5ff642");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("923c4e38-537b-4aba-8261-742f5c5df9b9"),
                column: "ConcurrencyStamp",
                value: "63bdda2e-1e7f-4c26-a0cf-d630fa95ea77");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("93a1489d-f4f7-4b33-a755-6c816a467ad3"),
                column: "ConcurrencyStamp",
                value: "9cd2f2dc-627c-4e62-af1e-205869432dd1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3f9de05-b0d7-4f83-8c73-95f410cc5237", "AQAAAAEAACcQAAAAEH1qBHKrnYgcLS559wU3DjdyTHaAzyzqi1LKsVxL1yDdIVYvsVlIXuDwgEhIpoOq8w==", "fbca8d25-d388-43f0-b623-059611e83955" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4703242-36a0-426b-81b8-0c7336606613"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bc7152e-765a-44e5-a500-47941960a1c5", "AQAAAAEAACcQAAAAEGvrB9XmzYhYNk0A2w3pkKmr1at0GFxaV01Iw/xn1pgMZ83e74QkUQCOGEYW9O6yjw==", "e9fcca9e-a70e-42aa-bd2d-86695efc2ccd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbf17ff9-151e-449b-822e-05a80274af0e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4014d64-c760-4e4d-8d42-3f9ac0e35f77", "AQAAAAEAACcQAAAAEF1Qaj5hyNzvd8czdfDE/J9wiGS4o2K17QyL4kiZEjXnEAfpTVTv43g4yMrCiPjwCA==", "2ff86886-6164-41ee-851e-5d787328340c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efac4210-d6f1-471d-91df-7c17dc81318d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5677428f-7e3e-455e-a1d3-f136e85f7ccb", "AQAAAAEAACcQAAAAEDAOIrQq5BtrMaSlskOdi5xZCOVyUN05Pmlmf6RydWkVmR5k0I6Jd2dPn0BbwK8xRA==", "dbb3f861-bf2a-4039-8784-c9a54d7b0b45" });
        }
    }
}
