using bike_club.DbContext;
using Microsoft.EntityFrameworkCore;

namespace bike_club.Models.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private BikeClubContext _context;

        public BikeRepository()
        {
            _context = new BikeClubContext();
        }

        public MBike Add(MBike entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return GetById(entity.Id);
        }

        public MBike Update(MBike entity)
        {
            var bikeToUpdate = _context.Bikes.First(bike => bike.Id == entity.Id);
            _context.Entry(bikeToUpdate).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return GetById(entity.Id);
        }

        public string Delete(MBike entity)
        {
            var bikeToDelete = _context.Bikes.First(bike => bike.Id == entity.Id);
            _context.Bikes.Remove(bikeToDelete);
            _context.SaveChanges();
            return bikeToDelete.Id == entity.Id ? "Wasn't deleted" : "Was successfully deleted!";
        }

        public MBike GetById(Guid id)
        {
            var user = _context.Bikes.Include(bike => bike.User)
                .FirstOrDefault(bike => bike.Id == id);
            return user;
        }

        public List<MBike> GetAll()
        {
            return _context.Bikes.ToList();
        }
    }
}
