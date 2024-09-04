using bike_club.DbContext;
using Microsoft.EntityFrameworkCore;

namespace bike_club.Models.Repositories
{
    public interface IBikeRepository : IRepository<MBike>
    {
    }
}
