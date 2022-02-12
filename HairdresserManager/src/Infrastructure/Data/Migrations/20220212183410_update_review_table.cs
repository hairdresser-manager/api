using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class update_review_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Clients_ClientId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Employees_EmployeeId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Services_ServiceId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ClientId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_EmployeeId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ServiceId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b521992f-e512-42a7-92f2-ddedd023359d"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("97383ff2-1262-4fbf-8cad-6c5ee766f4dc"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("339e893d-b310-4e03-8a53-545d63d314f1"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("97383ff2-1262-4fbf-8cad-6c5ee766f4dc"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("339e893d-b310-4e03-8a53-545d63d314f1"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("97383ff2-1262-4fbf-8cad-6c5ee766f4dc"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("339e893d-b310-4e03-8a53-545d63d314f1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97383ff2-1262-4fbf-8cad-6c5ee766f4dc"));

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Reviews",
                newName: "AppointmentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AppointmentId",
                table: "Reviews",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Appointments_AppointmentId",
                table: "Reviews",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Appointments_AppointmentId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_AppointmentId",
                table: "Reviews");

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
                name: "AppointmentId",
                table: "Reviews",
                newName: "ServiceId");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("b521992f-e512-42a7-92f2-ddedd023359d"), "31e605e4-1539-4993-b5d6-775b860cfc6c", "User", "User" },
                    { new Guid("97383ff2-1262-4fbf-8cad-6c5ee766f4dc"), "2749a712-628f-4d2f-8c2d-ae3d98890297", "Employee", "Employee" },
                    { new Guid("339e893d-b310-4e03-8a53-545d63d314f1"), "da843880-2a07-444e-ae8f-edda0d587dd9", "Admin", "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f56f67c9-d17f-4ef9-b5e9-9e985f1856b7", "AQAAAAEAACcQAAAAEETfNCo9igoVGk3Bt50OC3w3o+h317Znd1m7sp70tcuI9gwv3/9AeLOSTtue5dGabw==", "d84db66f-3601-4d9d-8345-77abe7a24fb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4703242-36a0-426b-81b8-0c7336606613"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a989539-2e2d-420f-98cf-8edc7313befa", "AQAAAAEAACcQAAAAECfHVe7W30+H7e5prKqG+B6QM5DDUSPZAa4DaasbZChdXjyEKDa4cN71OldoAFbCZg==", "ec062632-cc98-437b-bea7-ae589a94f06f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbf17ff9-151e-449b-822e-05a80274af0e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "888a5820-a492-4859-a3be-f7e33cfee1b6", "AQAAAAEAACcQAAAAEHj2Ff9QbadXiL3sYY0CLNDvSTFtf+fCbQQ4LtF/60o0dUHRc3msjBhGFA9IOPj5Kw==", "9108269b-8272-4756-8d43-1b4fef904192" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efac4210-d6f1-471d-91df-7c17dc81318d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d468e487-6d60-4034-80cc-3ce4aeb3c51a", "AQAAAAEAACcQAAAAECImItlstKxHnfkuu5pQV9b+mx8EOApMbS34Tz0HQxITq7G0i1xDy95JQEWUi2gi5A==", "08f9736e-81c1-4a82-acb0-5ddb61fe74ac" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("97383ff2-1262-4fbf-8cad-6c5ee766f4dc"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") },
                    { new Guid("97383ff2-1262-4fbf-8cad-6c5ee766f4dc"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") },
                    { new Guid("97383ff2-1262-4fbf-8cad-6c5ee766f4dc"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") },
                    { new Guid("339e893d-b310-4e03-8a53-545d63d314f1"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") },
                    { new Guid("339e893d-b310-4e03-8a53-545d63d314f1"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClientId",
                table: "Reviews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_EmployeeId",
                table: "Reviews",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ServiceId",
                table: "Reviews",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Clients_ClientId",
                table: "Reviews",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Employees_EmployeeId",
                table: "Reviews",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Services_ServiceId",
                table: "Reviews",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
