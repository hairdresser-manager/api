using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class add_description_to_service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7a5e0594-9895-47c5-825f-17d6eb1654a2"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9ccb3309-7244-4384-8e18-a73ae0ea12a0"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9ccb3309-7244-4384-8e18-a73ae0ea12a0"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e0aa94bb-0183-42ad-aea8-3c2656924462"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e0aa94bb-0183-42ad-aea8-3c2656924462"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9ccb3309-7244-4384-8e18-a73ae0ea12a0"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9ccb3309-7244-4384-8e18-a73ae0ea12a0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e0aa94bb-0183-42ad-aea8-3c2656924462"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Description",
                table: "Services");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7a5e0594-9895-47c5-825f-17d6eb1654a2"), "34cea050-8506-4a11-b60a-289640ce3c67", "User", "User" },
                    { new Guid("9ccb3309-7244-4384-8e18-a73ae0ea12a0"), "f539eb70-a488-4455-aa81-ff1c0b00c444", "Employee", "Employee" },
                    { new Guid("e0aa94bb-0183-42ad-aea8-3c2656924462"), "d331f677-a27a-4a73-b109-f30bf5c2d677", "Admin", "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fa1521b-d219-4761-8b46-883bb761b182", "AQAAAAEAACcQAAAAEHCy4wLRZP5YTBeTCRG9bRHTGiaM4itmYDBEah0aytFhDTqaI2hL0/1DDRRYYPT8mA==", "ef3b9bee-8ff5-4181-9d7e-dd7a0f1a8c05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4703242-36a0-426b-81b8-0c7336606613"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9699ae66-e736-472b-a626-6844dd388782", "AQAAAAEAACcQAAAAEAJsB4hLHQz7oXO8kd95CTli8vYkmeis2sQuwFAEpFsDuffqQ+oxVLh3z8JUiirLSg==", "fa84ee89-7378-44a6-9c48-3d2bebd5da46" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbf17ff9-151e-449b-822e-05a80274af0e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d2e0ca5-b95f-452a-a979-8e85b70fcd47", "AQAAAAEAACcQAAAAEJglQEQgdXIXiuZyo7kz1KBRhl/C28VUOAFaRhV1fkqb3fWaJbJNzuZurTznu7OpZQ==", "24a848a5-a2c6-4b12-96d9-14085897c3f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efac4210-d6f1-471d-91df-7c17dc81318d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13313bc7-a119-432d-aa55-549d0e9c9bdb", "AQAAAAEAACcQAAAAEFFE/Vld64pr5ZTF4SRqvNYC3V0asFMeMJCJy1D2QdUl4M+rONOkVKz3PwR2msTIYw==", "e4e243ac-09c8-497b-9b38-a4a23a8d998b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("9ccb3309-7244-4384-8e18-a73ae0ea12a0"), new Guid("08346f6b-8180-4d2e-bf68-2ce50fe1d363") },
                    { new Guid("9ccb3309-7244-4384-8e18-a73ae0ea12a0"), new Guid("efac4210-d6f1-471d-91df-7c17dc81318d") },
                    { new Guid("9ccb3309-7244-4384-8e18-a73ae0ea12a0"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") },
                    { new Guid("e0aa94bb-0183-42ad-aea8-3c2656924462"), new Guid("bbf17ff9-151e-449b-822e-05a80274af0e") },
                    { new Guid("e0aa94bb-0183-42ad-aea8-3c2656924462"), new Guid("a4703242-36a0-426b-81b8-0c7336606613") }
                });
        }
    }
}
