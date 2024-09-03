namespace bike_club.Models.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void Update(T entity);
        string Delete(T entity);
        T GetById(Guid id);
        List<T> GetAll();
    }
}
