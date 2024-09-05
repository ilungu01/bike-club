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

        public MUser Update(MUser entity)
        {
            var userToUpdate = GetById(entity.Id);
            _context.Entry(userToUpdate).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            using var secondContext = new BikeClubContext();
            if (entity.Bike?.Count > 0)
            {
                userToUpdate.Bike?.Clear();
                foreach (var bike in entity.Bike)
                {
                    secondContext.Entry(bike).State = EntityState.Unchanged;
                    userToUpdate.Bike?.Add(bike);
                }
            }

            if (entity.Memberships?.Count > 0)
            {
                userToUpdate.Memberships?.Clear();
                foreach (var membership in entity.Memberships)
                {
                    secondContext.Entry(membership).State = EntityState.Unchanged;
                    userToUpdate.Memberships?.Add(membership);
                }
            }

            secondContext.Attach(userToUpdate);
            secondContext.SaveChanges();
            return GetById(entity.Id);
        }

        public string Delete(MUser entity)
        {
            var userToDelete = GetById(entity.Id);
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return userToDelete.Id == entity.Id ? "Wasn't deleted" : "Was successfully deleted!";
        }

        public MUser GetById(Guid id)
        {
            var user = _context.Users.Include(bike => bike.Bike)
                .Include(membership => membership.Memberships)
                .First(user => user.Id == id);
            return user;
        }

        public MUser GetByTerm(string email, string password)
        {
            var user = _context.Users.Include(bike => bike.Bike)
                .Include(role => role.Role)
                .Include(membership => membership.Memberships)
                .FirstOrDefault(user => (user.Email == email && user.PasswordHash== password));
            return user;
        }

        public List<MUser> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
