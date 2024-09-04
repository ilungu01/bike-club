namespace bike_club.Models.Repositories
{
    public interface IUserRepository : IRepository<MUser>
    {
        MUser GetByTerm(string email, string password);
    }
}
