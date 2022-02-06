using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class update_appointment_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d55a0399-3a64-4d2b-9884-ebb11eaca783"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a8be239-7e0b-4132-b965-3f2ce2747f62"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a8be239-7e0b-4132-b965-3f2ce2747f62"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("87cd99c9-1fea-4dd9-8a02-d6cb649ae7dd"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("87cd99c9-1fea-4dd9-8a02-d6cb649ae7dd"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a8be239-7e0b-4132-b965-3f2ce2747f62"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3a8be239-7e0b-4132-b965-3f2ce2747f62"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87cd99c9-1fea-4dd9-8a02-d6cb649ae7dd"));

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Taken",
                table: "Appointments",
                newName: "TookPlace");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Appointments",
                newName: "DateUtc");

            migrationBuilder.AddColumn<bool>(
                name: "Canceled",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Canceled",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "TookPlace",
                table: "Appointments",
                newName: "Taken");

            migrationBuilder.RenameColumn(
                name: "DateUtc",
                table: "Appointments",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "Hour",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("d55a0399-3a64-4d2b-9884-ebb11eaca783"), "a883ade5-8bf3-4341-a5d6-c2541a6f5fe6", "User", "User" },
                    { new Guid("3a8be239-7e0b-4132-b965-3f2ce2747f62"), "d14120ce-58dd-420d-a43f-45a17770a8a0", "Employee", "Employee" },
                    { new Guid("87cd99c9-1fea-4dd9-8a02-d6cb649ae7dd"), "ce93cbec-9e8a-4218-85d9-8d03cabc04a8", "Admin", "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c5f2719-3ef0-4c9b-bb1f-5ac2ea3da22d", "AQAAAAEAACcQAAAAEOLYLYoGQULjNE+ib1JOzJsOvoJkMr61OG5sIFGyPl+bAKu5ltlra77Pkg41Kzjgfw==", "80ec9595-1626-4d1a-a65d-9a09c75a2d2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4703242-36a0-426b-81b8-0c7336606613"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eee5479a-e512-4052-817c-e2236a2e19b3", "AQAAAAEAACcQAAAAEILVtV3ZEzgxWCebVql1mdxag2gAv99zG8j6tgm08deX7cux/7LlE4p//9BtRnL9XQ==", "464ece92-0ec9-4d5c-912c-4f19688c3d51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbf17ff9-151e-449b-822e-05a80274af0e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4598f830-eac7-45a0-bab5-b55eb1214088", "AQAAAAEAACcQAAAAEDzStX3rCQ61ssA2nv94wV3Kt6oPONeRv+A5hr74Sa5+IYp6rOB4XD3is3PzbkokBw==", "881177f5-43d0-4baf-8119-e09412fc3b6d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efac4210-d6f1-471d-91df-7c17dc81318d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60611190-2b0b-48a3-8b39-7039fff4c84c", "AQAAAAEAACcQAAAAEGue+yOKbFyP1NSv9cZBt0noHa8ZDnzjNwd+MIh9HJQmdGnHVLDmmof6Ko7isihaUw==", "16c722a6-6090-48eb-af88-9c6ded82db05" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3a8be239-7e0b-4132-b965-3f2ce2747f62"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") },
                    { new Guid("3a8be239-7e0b-4132-b965-3f2ce2747f62"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") },
                    { new Guid("3a8be239-7e0b-4132-b965-3f2ce2747f62"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") },
                    { new Guid("87cd99c9-1fea-4dd9-8a02-d6cb649ae7dd"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") },
                    { new Guid("87cd99c9-1fea-4dd9-8a02-d6cb649ae7dd"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") }
                });
        }
    }
}
