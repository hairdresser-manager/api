using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ServiceEmployeeRoleConfiguration : IEntityTypeConfiguration<ServiceEmployeeRole>
    {
        public void Configure(EntityTypeBuilder<ServiceEmployeeRole> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder.HasOne(s => s.Service)
                .WithMany(s => s.EmployeeRoles)
                .HasForeignKey(s => s.ServiceId);
            
            builder.HasOne(s => s.EmployeeRole)
                .WithMany(e => e.ServicesEmployeeRoles)
                .HasForeignKey(s => s.EmployeeRoleId);
        }
    }
}