using System;
using ApplicationCore.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Role = Infrastructure.Identity.Role;

namespace Infrastructure.Data
{
    public static class DataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var userRole = new Role
            {
                Id = new Guid("2F297D12-C986-455B-BBDB-7F696A809AAA"), Name = "User", NormalizedName = "User",
                ConcurrencyStamp = "c96363b2-6967-4b1b-9c1b-2768da5ff642"
            };
            var employeeRole = new Role
            {
                Id = new Guid("93A1489D-F4F7-4B33-A755-6C816A467AD3"), Name = "Employee", NormalizedName = "Employee",
                ConcurrencyStamp = "9cd2f2dc-627c-4e62-af1e-205869432dd1"
            };
            var administratorRole = new Role
            {
                Id = new Guid("923C4E38-537B-4ABA-8261-742F5C5DF9B9"), Name = "Admin", NormalizedName = "Admin",
                ConcurrencyStamp = "63bdda2e-1e7f-4c26-a0cf-d630fa95ea77"
            };

            modelBuilder.Entity<Role>().HasData(
                userRole, employeeRole, administratorRole
            );

            var admin = new User
            {
                Id = new Guid("BBF17FF9-151E-449B-822E-05A80274AF0E"),
                Email = "admin@example.com",
                NormalizedEmail = "admin@example.com".ToUpper(),
                UserName = "admin@example.com",
                NormalizedUserName = "admin@example.com".ToUpper(),
                FirstName = "Bill",
                LastName = "Gates",
                PhoneNumber = "0987654321",
                EmailConfirmed = true,
                ConcurrencyStamp = "8b4e7538-768e-41fe-8761-2fc1ac7552a3",
                PasswordHash = "AQAAAAEAACcQAAAAEGu33e3p9ajIN1HwxnMjxSoroZccobViGUbLhgAUaFx3ygIyXTQ5JdBkoDYLWpkDLQ==",
                SecurityStamp = "3af74bc5-ff55-4170-a3d1-042fde29ffdb"
            };

            var admin2 = new User
            {
                Id = new Guid("A4703242-36A0-426B-81B8-0C7336606613"),
                Email = "admin2@example.com",
                NormalizedEmail = "admin2@example.com".ToUpper(),
                UserName = "admin2@example.com",
                NormalizedUserName = "admin2@example.com".ToUpper(),
                FirstName = "Jeff",
                LastName = "Bezos",
                PhoneNumber = "567345764e56",
                ConcurrencyStamp = "ea084d52-18d8-4f5e-bac2-e78a972b0327",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEBkZguna1XIq5fUUGOhkI54nVoL52ne23Litw60ej/ojsVrNMmpieIT3AD39D3OD5w==",
                SecurityStamp = "6261012a-c386-4b3b-8fd8-e64e38a0a729"
            };

            var employee1 = new User
            {
                Id = new Guid("08346F6B-8180-4D2E-BF68-2CE50FE1D363"),
                Email = "employee1@example.com",
                NormalizedEmail = "employee1@example.com".ToUpper(),
                UserName = "employee1@example.com",
                NormalizedUserName = "employee1@example.com".ToUpper(),
                FirstName = "Bart",
                LastName = "Osh",
                PhoneNumber = "123456789",
                ConcurrencyStamp = "b847ff72-39e8-4438-a183-f0aa784eb731",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEOSJeu1Y1M7+hI+m8N87wuGGymwTWNorFjMFyCox5mOs4z8SAlhR6Ah2PZMADop+RA==",
                SecurityStamp = "83835e3a-00e6-43b6-a7a4-8177fd9ff8d3"
            };

            var employee2 = new User
            {
                Id = new Guid("EFAC4210-D6F1-471D-91DF-7C17DC81318D"),
                Email = "employee2@example.com",
                NormalizedEmail = "employee2@example.com".ToUpper(),
                UserName = "employee2@example.com",
                NormalizedUserName = "employee2@example.com".ToUpper(),
                FirstName = "Dwayne",
                LastName = "Johnson",
                PhoneNumber = "543215678",
                ConcurrencyStamp = "5b42bb4e-1b5a-4aab-8a30-e63748528700",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAECM9swt8QfobHnfKl3XZBMU10YKaHdil1TJnh55nfbxFbarsB0JSA0GLa/EFApQ84g==",
                SecurityStamp = "ea873fb4-4997-423e-9db8-77a84642a433"
            };

            modelBuilder.Entity<User>().HasData(
                admin, admin2, employee1, employee2
            );

            var userRole1 = new IdentityUserRole<Guid>
            {
                RoleId = administratorRole.Id, UserId = admin.Id
            };

            var userRole2 = new IdentityUserRole<Guid>
            {
                RoleId = employeeRole.Id, UserId = employee1.Id
            };

            var userRole3 = new IdentityUserRole<Guid>
            {
                RoleId = employeeRole.Id, UserId = employee2.Id
            };

            var userRole4 = new IdentityUserRole<Guid>
            {
                RoleId = employeeRole.Id, UserId = admin2.Id
            };

            var userRole5 = new IdentityUserRole<Guid>
            {
                RoleId = administratorRole.Id, UserId = admin2.Id
            };

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                userRole1, userRole2, userRole3, userRole4, userRole5
            );

            var employeeBartosh = new Employee
            {
                Id = 1,
                UserId = employee1.Id,
                Active = true,
                Nick = "Bartosh",
                Description = "Giga hairdresser",
                LowQualityAvatarUrl =
                    "https://images.chesscomfiles.com/uploads/v1/master_player/e4a20096-88e9-11eb-94e3-39aa30591f7c.1fdbd8e5.250x250o.1413e8d0bb72.jpeg",
                AvatarUrl = "https://moviecomicswhoswho.files.wordpress.com/2015/09/luke-cage.jpg"
            };

            var employeeRock = new Employee
            {
                Id = 2,
                UserId = employee2.Id,
                Active = true,
                Nick = "The Rock",
                Description = "Success isn't always about 'Greatness', it's about consistency.",
                LowQualityAvatarUrl =
                    "https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:good%2Cw_1200/MTc5NjIyODM0ODM2ODc0Mzc3/dwayne-the-rock-johnson-gettyimages-1061959920.jpg",
                AvatarUrl =
                    "https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:good%2Cw_1200/MTc5NjIyODM0ODM2ODc0Mzc3/dwayne-the-rock-johnson-gettyimages-1061959920.jpg"
            };

            var employeeJeff = new Employee
            {
                Id = 3,
                UserId = admin2.Id,
                Active = true,
                Nick = "Luke",
                Description = "When you want something, all the universe conspires in helping you to achieve it.",
                LowQualityAvatarUrl =
                    "https://techcentral.co.za/wp-content/uploads/2017/05/jeff-bezos-2156-1120-1024x532@2x.jpg",
                AvatarUrl = "https://techcentral.co.za/wp-content/uploads/2017/05/jeff-bezos-2156-1120-1024x532@2x.jpg"
            };

            modelBuilder.Entity<Employee>().HasData(
                employeeRock, employeeBartosh, employeeJeff
            );
        }
    }
}