using bike_club.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bike_club.DbContext.Schemes
{
    public class MembershipScheme : IEntityTypeConfiguration<MMembership>
    {
        public void Configure(EntityTypeBuilder<MMembership> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.StartDate)
                .IsRequired();
            builder.Property(m => m.EndDate)
                .IsRequired(false);
            builder.HasOne(m => m.User)
                .WithMany(u => u.Memberships)
                .HasForeignKey(m => m.UserId);
            builder.HasOne(m => m.MembershipType)
                .WithMany(mt => mt.Memberships)
                .HasForeignKey(m => m.MembershipTypeId);
        }
    }
}
