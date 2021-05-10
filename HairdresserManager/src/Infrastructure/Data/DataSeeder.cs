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
            var userRole = new Role {Id = Guid.NewGuid(), Name = "User", NormalizedName = "User"};
            var employeeRole = new Role {Id = Guid.NewGuid(), Name = "Employee", NormalizedName = "Employee"};
            var administratorRole = new Role
                {Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "Admin"};

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
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
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
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
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
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
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
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };

            var passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "zaq1@WSX");
            admin2.PasswordHash = passwordHasher.HashPassword(admin2, "zaq1@WSX");
            employee1.PasswordHash = passwordHasher.HashPassword(employee1, "zaq1@WSX");
            employee2.PasswordHash = passwordHasher.HashPassword(employee2, "zaq1@WSX");

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
                LowQualityAvatarUrl = "https://images.chesscomfiles.com/uploads/v1/master_player/e4a20096-88e9-11eb-94e3-39aa30591f7c.1fdbd8e5.250x250o.1413e8d0bb72.jpeg",
                AvatarUrl = "https://moviecomicswhoswho.files.wordpress.com/2015/09/luke-cage.jpg"
            };
            
            var employeeRock = new Employee
            {
                Id = 2,
                UserId = employee2.Id,
                Active = true, 
                Nick = "The Rock", 
                Description = "Success isn't always about 'Greatness', it's about consistency.",
                LowQualityAvatarUrl = "https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:good%2Cw_1200/MTc5NjIyODM0ODM2ODc0Mzc3/dwayne-the-rock-johnson-gettyimages-1061959920.jpg",
                AvatarUrl = "https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:good%2Cw_1200/MTc5NjIyODM0ODM2ODc0Mzc3/dwayne-the-rock-johnson-gettyimages-1061959920.jpg"
            };
            
            var employeeJeff = new Employee
            {
                Id = 3,
                UserId = admin2.Id,
                Active = true, 
                Nick = "Luke", 
                Description = "When you want something, all the universe conspires in helping you to achieve it.",
                LowQualityAvatarUrl = "https://techcentral.co.za/wp-content/uploads/2017/05/jeff-bezos-2156-1120-1024x532@2x.jpg",
                AvatarUrl = "https://techcentral.co.za/wp-content/uploads/2017/05/jeff-bezos-2156-1120-1024x532@2x.jpg"
            };
            
            modelBuilder.Entity<Employee>().HasData(
                employeeRock, employeeBartosh, employeeJeff
            );
        }
    }
}