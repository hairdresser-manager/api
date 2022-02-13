using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class update_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b847ff72-39e8-4438-a183-f0aa784eb731", "AQAAAAEAACcQAAAAEOSJeu1Y1M7+hI+m8N87wuGGymwTWNorFjMFyCox5mOs4z8SAlhR6Ah2PZMADop+RA==", "83835e3a-00e6-43b6-a7a4-8177fd9ff8d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4703242-36a0-426b-81b8-0c7336606613"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea084d52-18d8-4f5e-bac2-e78a972b0327", "AQAAAAEAACcQAAAAEBkZguna1XIq5fUUGOhkI54nVoL52ne23Litw60ej/ojsVrNMmpieIT3AD39D3OD5w==", "6261012a-c386-4b3b-8fd8-e64e38a0a729" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbf17ff9-151e-449b-822e-05a80274af0e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b4e7538-768e-41fe-8761-2fc1ac7552a3", "AQAAAAEAACcQAAAAEGu33e3p9ajIN1HwxnMjxSoroZccobViGUbLhgAUaFx3ygIyXTQ5JdBkoDYLWpkDLQ==", "3af74bc5-ff55-4170-a3d1-042fde29ffdb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efac4210-d6f1-471d-91df-7c17dc81318d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b42bb4e-1b5a-4aab-8a30-e63748528700", "AQAAAAEAACcQAAAAECM9swt8QfobHnfKl3XZBMU10YKaHdil1TJnh55nfbxFbarsB0JSA0GLa/EFApQ84g==", "ea873fb4-4997-423e-9db8-77a84642a433" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
