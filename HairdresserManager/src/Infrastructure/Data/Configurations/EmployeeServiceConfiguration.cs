using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EmployeeServiceConfiguration : IEntityTypeConfiguration<EmployeeService>
    {
        public void Configure(EntityTypeBuilder<EmployeeService> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .HasOne(s => s.Service)
                .WithMany(e => e.EmployeeServices)
                .HasForeignKey(e => e.ServiceId);
            
            builder
                .HasOne(s => s.Employee)
                .WithMany(e => e.EmployeeServices)
                .HasForeignKey(e => e.EmployeeId);
        }
    }
}