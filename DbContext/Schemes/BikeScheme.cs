using bike_club.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bike_club.DbContext.Schemes
{
    public class BikeScheme : IEntityTypeConfiguration<MBike>
    {
        public void Configure(EntityTypeBuilder<MBike> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Brand)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Model)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.SerialNumber)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.PurchaseDate)
                .IsRequired();
            builder.HasOne(b => b.User) 
                .WithMany(u => u.Bike) 
                .HasForeignKey(b => b.UserId);
        }
    }
}
