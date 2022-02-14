using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ReviewDetailsViewConfiguration : IEntityTypeConfiguration<ReviewDetailsView>
    {
        public void Configure(EntityTypeBuilder<ReviewDetailsView> builder)
        {
            builder
                .HasNoKey();

            builder
                .ToView("ReviewDetailsView");
        }
    }
}