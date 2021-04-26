using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User = Infrastructure.Identity.User;

namespace Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne<Client>(user => user.Client)
                .WithOne()
                .HasForeignKey<Client>(client => client.UserId);
            
            builder
                .HasOne<Employee>(user => user.Employee)
                .WithOne()
                .HasForeignKey<Employee>(employee => employee.UserId);
        }
    }
}