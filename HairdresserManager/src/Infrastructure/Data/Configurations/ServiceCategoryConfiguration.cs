using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasOne(x => x.Service)
                .WithMany(r => r.Categories)
                .HasForeignKey(s => s.ServiceId);
            
            builder
                .HasOne(x => x.Category)
                .WithMany(r => r.ServiceCategories)
                .HasForeignKey(s => s.CategoryId);
        }
    }
}