using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Employee)
                .WithMany(e => e.Roles)
                .HasForeignKey(e => e.EmployeeId);
            
            builder.HasOne(e => e.Role)
                .WithMany(e => e.EmployeeRoles)
                .HasForeignKey(e => e.RoleId);
        }
    }
}