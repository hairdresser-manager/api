using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class add_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("f21c3656-118f-4457-959b-3167a80fd824"), "ceb21d41-6388-4b40-8020-92a58e29ef7a", "User", "User" },
                    { new Guid("04ef5812-b526-439c-8b40-36c921d7f21d"), "f89c4903-189e-4e72-9fba-d85a44e276ae", "Employee", "Employee" },
                    { new Guid("6af38d53-994b-47ce-953c-95fc7a0da269"), "6213e3c2-bc8b-4954-a566-68aaf8dcd6a2", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("31083e5c-0540-4e1a-ae9e-f77fd2bfa68a"), 0, "fcc17600-3aa1-4461-933a-b9822c18e506", "admin@example.com", true, "Bill", "Gates", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEA+rDLDrNfuN/vD1mhWxuVEsa7c2eVjLhxvpqYQxUxcnf6g+IE23EPKSvOlNOWUl2g==", "0987654321", false, "6c8ba72d-60ee-4b72-9db4-6744f07d46e4", false, "admin@example.com" },
                    { new Guid("8c2de80f-1d53-4537-adab-02d52c42c0b4"), 0, "a61b8289-5f68-42dd-a437-ef92f95a4f46", "admin2@example.com", true, "Jeff", "Bezos", false, null, "ADMIN2@EXAMPLE.COM", "ADMIN2@EXAMPLE.COM", "AQAAAAEAACcQAAAAEMvRPIWbn64grgK+njLxCPJU3tyfKkT25B2f0wl8eBe30HUuWh+4aYczg9Qluua+Ug==", "567345764e56", false, "d1840e87-fd39-4f35-bb4b-426675ac88c5", false, "admin2@example.com" },
                    { new Guid("3810e55b-9045-4a87-a52e-65dca721ee75"), 0, "cdacae9b-5844-4e2e-b559-d7d45ae03b2f", "employee1@example.com", true, "Bart", "Osh", false, null, "EMPLOYEE1@EXAMPLE.COM", "EMPLOYEE1@EXAMPLE.COM", "AQAAAAEAACcQAAAAEFQjElNsalfSr2Cn+Ej0ItH9wmRfA4ZGB050tbvQ3Y2w+0Fk3/EB276B58uFQnXOPg==", "123456789", false, "d8e92151-1b08-4db1-8673-73530d23ea38", false, "employee1@example.com" },
                    { new Guid("68f1bf0a-c848-4978-995e-c92126c88e06"), 0, "b2d0a208-62ad-449d-8065-79f9bd472ec4", "employee2@example.com", true, "Dwayne", "Johnson", false, null, "EMPLOYEE2@EXAMPLE.COM", "EMPLOYEE2@EXAMPLE.COM", "AQAAAAEAACcQAAAAELILPv/dQ6vpwrk3BhHWN7J9RRJSTseQcy13Y0YZv2K2t8mN4xYsPwtRxPRvlhJPAQ==", "543215678", false, "d582b502-d2ac-4287-a617-ef5bf11754d8", false, "employee2@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6af38d53-994b-47ce-953c-95fc7a0da269"), new Guid("31083e5c-0540-4e1a-ae9e-f77fd2bfa68a") },
                    { new Guid("04ef5812-b526-439c-8b40-36c921d7f21d"), new Guid("8c2de80f-1d53-4537-adab-02d52c42c0b4") },
                    { new Guid("6af38d53-994b-47ce-953c-95fc7a0da269"), new Guid("8c2de80f-1d53-4537-adab-02d52c42c0b4") },
                    { new Guid("04ef5812-b526-439c-8b40-36c921d7f21d"), new Guid("3810e55b-9045-4a87-a52e-65dca721ee75") },
                    { new Guid("04ef5812-b526-439c-8b40-36c921d7f21d"), new Guid("68f1bf0a-c848-4978-995e-c92126c88e06") }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "AvatarUrl", "Description", "LowQualityAvatarUrl", "Nick", "UserId" },
                values: new object[,]
                {
                    { 3, true, "https://techcentral.co.za/wp-content/uploads/2017/05/jeff-bezos-2156-1120-1024x532@2x.jpg", "Success isn't always about 'Greatness', it's about consistency.", "https://techcentral.co.za/wp-content/uploads/2017/05/jeff-bezos-2156-1120-1024x532@2x.jpg", "The Rock", new Guid("8c2de80f-1d53-4537-adab-02d52c42c0b4") },
                    { 1, true, "https://scontent-frt3-1.cdninstagram.com/v/t51.2885-15/sh0.08/e35/s640x640/164620128_800510077236657_4464242640656376019_n.jpg?tp=1&_nc_ht=scontent-frt3-1.cdninstagram.com&_nc_cat=109&_nc_ohc=fBzuRWUd9LcAX9CTNqI&edm=AP_V10EBAAAA&ccb=7-4&oh=1f5e24c0f15ad60e5d567f39f1e32288&oe=60B56733&_nc_sid=4f375e", "Giga hairdresser", "https://images.chesscomfiles.com/uploads/v1/master_player/e4a20096-88e9-11eb-94e3-39aa30591f7c.1fdbd8e5.250x250o.1413e8d0bb72.jpeg", "Bartosh", new Guid("3810e55b-9045-4a87-a52e-65dca721ee75") },
                    { 2, true, "https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:good%2Cw_1200/MTc5NjIyODM0ODM2ODc0Mzc3/dwayne-the-rock-johnson-gettyimages-1061959920.jpg", "Success isn't always about 'Greatness', it's about consistency.", "https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:good%2Cw_1200/MTc5NjIyODM0ODM2ODc0Mzc3/dwayne-the-rock-johnson-gettyimages-1061959920.jpg", "The Rock", new Guid("68f1bf0a-c848-4978-995e-c92126c88e06") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f21c3656-118f-4457-959b-3167a80fd824"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6af38d53-994b-47ce-953c-95fc7a0da269"), new Guid("31083e5c-0540-4e1a-ae9e-f77fd2bfa68a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("04ef5812-b526-439c-8b40-36c921d7f21d"), new Guid("3810e55b-9045-4a87-a52e-65dca721ee75") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("04ef5812-b526-439c-8b40-36c921d7f21d"), new Guid("68f1bf0a-c848-4978-995e-c92126c88e06") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("04ef5812-b526-439c-8b40-36c921d7f21d"), new Guid("8c2de80f-1d53-4537-adab-02d52c42c0b4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6af38d53-994b-47ce-953c-95fc7a0da269"), new Guid("8c2de80f-1d53-4537-adab-02d52c42c0b4") });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04ef5812-b526-439c-8b40-36c921d7f21d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6af38d53-994b-47ce-953c-95fc7a0da269"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31083e5c-0540-4e1a-ae9e-f77fd2bfa68a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3810e55b-9045-4a87-a52e-65dca721ee75"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("68f1bf0a-c848-4978-995e-c92126c88e06"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c2de80f-1d53-4537-adab-02d52c42c0b4"));
        }
    }
}
