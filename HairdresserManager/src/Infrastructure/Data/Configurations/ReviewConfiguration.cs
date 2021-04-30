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
                .HasOne(x => x.Client)
                .WithMany(r => r.Reviews)
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(x => x.Employee)
                .WithMany(r => r.Reviews)
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(x => x.Service)
                .WithMany(r => r.Reviews)
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}