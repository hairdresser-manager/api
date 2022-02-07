using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class remove_utc_prefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04144e51-20e5-46a6-8066-920af251f604"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ab0b056b-dbd9-4d89-aee2-82a510fc4691"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ab0b056b-dbd9-4d89-aee2-82a510fc4691"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1b18459-1d75-4252-8990-4fe8e732f210"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1b18459-1d75-4252-8990-4fe8e732f210"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ab0b056b-dbd9-4d89-aee2-82a510fc4691"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab0b056b-dbd9-4d89-aee2-82a510fc4691"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1b18459-1d75-4252-8990-4fe8e732f210"));

            migrationBuilder.RenameColumn(
                name: "DateUtc",
                table: "Appointments",
                newName: "Date");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Appointments",
                newName: "DateUtc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("04144e51-20e5-46a6-8066-920af251f604"), "a302ce76-d761-4629-a8c9-88f50cb64673", "User", "User" },
                    { new Guid("ab0b056b-dbd9-4d89-aee2-82a510fc4691"), "3cf1496a-f0dd-4494-af22-6707e0bac061", "Employee", "Employee" },
                    { new Guid("e1b18459-1d75-4252-8990-4fe8e732f210"), "56679db2-b6ea-4b7e-be82-7e125c3881ee", "Admin", "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84658f82-bcc2-439f-9a33-344255f7a5b6", "AQAAAAEAACcQAAAAECKfShmv2j3cOB0Ykd+Hrwgk3s6harTSHq+ncMI9GkGg2jjGhrCrZI7H8Yk1JupBNQ==", "7bf0b03d-3f6a-45e6-85d8-821cd6d218bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4703242-36a0-426b-81b8-0c7336606613"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee2e9541-6414-4d62-8663-7c3a5e7d710e", "AQAAAAEAACcQAAAAEDKOdOpCMFWfvyM/W4MKpQqjDPmBdUf7wh/j2FWrjcW06irI7SIoJXGDctle6WNybA==", "8b622d56-bf3d-4e23-bed1-c944fec0c6fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbf17ff9-151e-449b-822e-05a80274af0e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe53b843-8c57-418a-9f35-cf7eac49c119", "AQAAAAEAACcQAAAAEF2OQC52l9sxBkKhkYPVJdn13HVMf+9n9ENZidB3D5HYYLnKrMVL07zNYby/305dSw==", "dd38b218-aee9-4245-9f98-638c0664032a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efac4210-d6f1-471d-91df-7c17dc81318d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cf6997f-4b2c-4e19-bcd8-bad6551f44a1", "AQAAAAEAACcQAAAAEI0ZEhtAmCYc3YBYrcugUvpha0yVzKOk47JywfaRoITWX0JrgK3HcEn0UDe5Sn+nCA==", "451ff3cd-7fd7-4ca7-b3b5-22348a148e6b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("ab0b056b-dbd9-4d89-aee2-82a510fc4691"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") },
                    { new Guid("ab0b056b-dbd9-4d89-aee2-82a510fc4691"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") },
                    { new Guid("ab0b056b-dbd9-4d89-aee2-82a510fc4691"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") },
                    { new Guid("e1b18459-1d75-4252-8990-4fe8e732f210"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") },
                    { new Guid("e1b18459-1d75-4252-8990-4fe8e732f210"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") }
                });
        }
    }
}
