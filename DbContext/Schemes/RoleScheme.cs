using bike_club.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bike_club.DbContext.Schemes
{
    public class RoleScheme : IEntityTypeConfiguration<MRole>
    {
        public void Configure(EntityTypeBuilder<MRole> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(r => r.Description)
                .HasMaxLength(250);
        }
    }
}
