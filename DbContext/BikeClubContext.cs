using bike_club.DbContext.Schemes;
using bike_club.Models;
using Microsoft.Data.SqlClient;

namespace bike_club.DbContext;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

public class BikeClubContext : DbContext
{
    public DbSet<MUser> Users { get; set; }
    public DbSet<MRole> Roles { get; set; }
    public DbSet<MBike> Bikes { get; set; }
    public DbSet<MMembership> Memberships { get; set; }

    public DbSet<MMembershipType> MembershipTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=BLABLABLA;database=BikeClub;Integrated Security=True;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserScheme());
        modelBuilder.ApplyConfiguration(new BikeScheme());
        modelBuilder.ApplyConfiguration(new RoleScheme());
        modelBuilder.ApplyConfiguration(new MembershipScheme());
        modelBuilder.ApplyConfiguration(new MembershipTypeScheme());
        base.OnModelCreating(modelBuilder);
    }
}
