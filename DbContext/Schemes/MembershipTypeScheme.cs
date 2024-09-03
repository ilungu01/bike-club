using bike_club.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bike_club.DbContext.Schemes
{
    public class MembershipTypeScheme : IEntityTypeConfiguration<MMembershipType>
    {
        public void Configure(EntityTypeBuilder<MMembershipType> builder)
        {
            builder.HasKey(mt => mt.Id);
            builder.Property(mt => mt.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(mt => mt.Description)
                .HasMaxLength(250);
            builder.Property(mt => mt.SubscriptionLengthInMonths)
                .IsRequired();
        }
    }
}
