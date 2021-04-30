using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ServicesCategoryConfiguration : IEntityTypeConfiguration<ServicesCategory>
    {
        public void Configure(EntityTypeBuilder<ServicesCategory> builder)
        {
            builder
                .HasKey(e => e.Id);
        }
    }
}