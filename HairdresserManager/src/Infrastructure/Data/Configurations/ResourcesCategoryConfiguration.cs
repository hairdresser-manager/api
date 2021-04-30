using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ResourcesCategoryConfiguration : IEntityTypeConfiguration<ResourcesCategory>
    {
        public void Configure(EntityTypeBuilder<ResourcesCategory> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}