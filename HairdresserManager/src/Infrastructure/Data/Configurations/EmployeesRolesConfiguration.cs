using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EmployeesRolesConfiguration : IEntityTypeConfiguration<EmployeesRole>
    {
        public void Configure(EntityTypeBuilder<EmployeesRole> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}