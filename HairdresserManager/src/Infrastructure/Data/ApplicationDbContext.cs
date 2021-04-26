using System;
using ApplicationCore.Entities;
using Infrastructure.Data.Configurations;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User = Infrastructure.Identity.User;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new ClientConfiguration());

            builder
                .ApplyConfiguration(new EmployeeConfiguration());

            builder
                .ApplyConfiguration(new ReviewConfiguration());
            
            builder
                .ApplyConfiguration(new ServiceConfiguration());
        }
    }
}