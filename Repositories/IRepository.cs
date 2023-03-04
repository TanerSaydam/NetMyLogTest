using WebApplication9.Models.Abstraction;

namespace WebApplication9.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
        Task AddAsync(T entity, bool isLog = true);
        Task RemoeById(int id);
        Task SaveChanges();
    }
}
