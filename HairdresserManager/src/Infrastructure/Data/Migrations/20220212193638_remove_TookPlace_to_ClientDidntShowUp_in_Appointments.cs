using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class remove_TookPlace_to_ClientDidntShowUp_in_Appointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2aa267c0-d6f9-425c-9563-2abcdf23b997"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d226f67-3c09-45c9-88da-2ac276637110"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d226f67-3c09-45c9-88da-2ac276637110"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fe5df05c-8a10-47bc-b1b4-f49298a9ba37"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fe5df05c-8a10-47bc-b1b4-f49298a9ba37"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d226f67-3c09-45c9-88da-2ac276637110"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d226f67-3c09-45c9-88da-2ac276637110"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe5df05c-8a10-47bc-b1b4-f49298a9ba37"));

            migrationBuilder.RenameColumn(
                name: "TookPlace",
                table: "Appointments",
                newName: "ClientDidntShowUp");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2f297d12-c986-455b-bbdb-7f696a809aaa"), "c96363b2-6967-4b1b-9c1b-2768da5ff642", "User", "User" },
                    { new Guid("93a1489d-f4f7-4b33-a755-6c816a467ad3"), "9cd2f2dc-627c-4e62-af1e-205869432dd1", "Employee", "Employee" },
                    { new Guid("923c4e38-537b-4aba-8261-742f5c5df9b9"), "63bdda2e-1e7f-4c26-a0cf-d630fa95ea77", "Admin", "Admin" }
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("93a1489d-f4f7-4b33-a755-6c816a467ad3"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") },
                    { new Guid("93a1489d-f4f7-4b33-a755-6c816a467ad3"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") },
                    { new Guid("93a1489d-f4f7-4b33-a755-6c816a467ad3"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") },
                    { new Guid("923c4e38-537b-4aba-8261-742f5c5df9b9"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") },
                    { new Guid("923c4e38-537b-4aba-8261-742f5c5df9b9"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f297d12-c986-455b-bbdb-7f696a809aaa"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("93a1489d-f4f7-4b33-a755-6c816a467ad3"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("923c4e38-537b-4aba-8261-742f5c5df9b9"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("93a1489d-f4f7-4b33-a755-6c816a467ad3"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("923c4e38-537b-4aba-8261-742f5c5df9b9"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("93a1489d-f4f7-4b33-a755-6c816a467ad3"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("923c4e38-537b-4aba-8261-742f5c5df9b9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("93a1489d-f4f7-4b33-a755-6c816a467ad3"));

            migrationBuilder.RenameColumn(
                name: "ClientDidntShowUp",
                table: "Appointments",
                newName: "TookPlace");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2aa267c0-d6f9-425c-9563-2abcdf23b997"), "1bbfef8d-d11e-4b65-bb11-6fc46287e167", "User", "User" },
                    { new Guid("8d226f67-3c09-45c9-88da-2ac276637110"), "9e73fb17-2c72-4076-9400-49c3c8a94a15", "Employee", "Employee" },
                    { new Guid("fe5df05c-8a10-47bc-b1b4-f49298a9ba37"), "7f93fb5f-ec23-463e-8543-b594afe54c6d", "Admin", "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b847ff72-39e8-4438-a183-f0aa784eb731", "AQAAAAEAACcQAAAAEKMTL8X4sFUSIPfGg+BjmlbPm7oqB2gs6D6C0gwzzGRMDfmVn4T81e086tmx6YZBUQ==", "76e1b3cb-afdd-4cc3-b26f-4086b8954f58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4703242-36a0-426b-81b8-0c7336606613"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea084d52-18d8-4f5e-bac2-e78a972b0327", "AQAAAAEAACcQAAAAEObGuKoyoF7NH+FmjCMsQcN4xHjt6hLa62PBLGCwaOnuH7BfnyUUaYlNDscSKhWTnQ==", "5404ca99-4d57-4929-975f-d39c3e61b22b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbf17ff9-151e-449b-822e-05a80274af0e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b4e7538-768e-41fe-8761-2fc1ac7552a3", "AQAAAAEAACcQAAAAEI/kG5Lz8SgIqUSXN/IBBTODIHOhDg4GLUSLO/zkjAjT6qXDyN8ZzMPmo0aO7tJwlg==", "45ec87cd-59f3-4ec4-bd99-4069bf69fdea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efac4210-d6f1-471d-91df-7c17dc81318d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b42bb4e-1b5a-4aab-8a30-e63748528700", "AQAAAAEAACcQAAAAEIu/gSINBFzEURPk00Ta0WnbGGjjvG2fT/3IwpksHRQGSVn2TXXxhj7S24FNHLnOFA==", "b97ef51f-0dc0-460e-b3f6-3f36a0803ee5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8d226f67-3c09-45c9-88da-2ac276637110"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") },
                    { new Guid("8d226f67-3c09-45c9-88da-2ac276637110"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") },
                    { new Guid("8d226f67-3c09-45c9-88da-2ac276637110"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") },
                    { new Guid("fe5df05c-8a10-47bc-b1b4-f49298a9ba37"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") },
                    { new Guid("fe5df05c-8a10-47bc-b1b4-f49298a9ba37"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") }
                });
        }
    }
}
