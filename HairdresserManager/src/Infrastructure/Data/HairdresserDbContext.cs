using System;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data.Configurations;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Role = Infrastructure.Identity.Role;

namespace Infrastructure.Data
{
    public class HairdresserDbContext : IdentityDbContext<User, Role, Guid>, IHairdresserDbContext
    {
        public HairdresserDbContext(DbContextOptions<HairdresserDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new AppointmentConfiguration())
                .ApplyConfiguration(new ClientConfiguration())
                .ApplyConfiguration(new DayOffConfiguration())
                .ApplyConfiguration(new EmployeeConfiguration())
                .ApplyConfiguration(new EmployeeServiceConfiguration())
                .ApplyConfiguration(new RefreshTokenConfiguration())
                .ApplyConfiguration(new ResourceConfiguration())
                .ApplyConfiguration(new ResourcesCategoryConfiguration())
                .ApplyConfiguration(new ReviewConfiguration())
                .ApplyConfiguration(new ScheduleConfiguration())
                .ApplyConfiguration(new ServiceCategoryConfiguration())
                .ApplyConfiguration(new ServiceConfiguration())
                .ApplyConfiguration(new ServicesCategoryConfiguration())
                .ApplyConfiguration(new UserConfiguration());
            
            builder.Seed();
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeService> EmployeeService { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourcesCategory> ResourcesCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServicesCategory> ServicesCategories { get; set; }
        public DbSet<DayOff> DaysOff { get; set; }
    }
}