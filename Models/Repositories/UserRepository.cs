using bike_club.DbContext;
using Microsoft.EntityFrameworkCore;

namespace bike_club.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private BikeClubContext _context;

        public UserRepository()
        {
            _context = new BikeClubContext();
        }

        public MUser Add(MUser entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return GetById(entity.Id);
        }

        public void Update(MUser entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(MUser entity)
        {
            var userToDelete = _context.Users.FirstOrDefault(user => user.Id == entity.Id);
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return _context.Users.FirstOrDefault(user => user.Id == entity.Id).Id == entity.Id ? "Wasn't deleted" : "Was successfully deleted!";
        }

        public MUser GetById(Guid id)
        {
            var user = _context.Users.Include(bike => bike.Bike)
                .Include(membership => membership.Memberships)
                .FirstOrDefault(user => user.Id == id);
            return user;
        }

        public MUser GetByTerm(string firstName, string lastName)
        {
            var user = _context.Users.Include(bike => bike.Bike)
                .Include(membership => membership.Memberships)
                .FirstOrDefault(user => (user.FirstName == firstName && user.LastName == lastName));
            return user;
        }

        public List<MUser> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
