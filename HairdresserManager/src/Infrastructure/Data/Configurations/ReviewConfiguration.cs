using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasOne(review => review.Appointment)
                .WithOne(appointment => appointment.Review)
                .HasForeignKey<Review>(review => review.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}