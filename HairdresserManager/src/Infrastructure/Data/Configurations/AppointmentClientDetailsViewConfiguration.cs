using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class AppointmentClientDetailsViewConfiguration : IEntityTypeConfiguration<AppointmentClientDetailsView>
    {
        public void Configure(EntityTypeBuilder<AppointmentClientDetailsView> builder)
        {
            builder
                .HasNoKey();

            builder
                .ToView("AppointmentClientDetailsView");
        }
    }
}