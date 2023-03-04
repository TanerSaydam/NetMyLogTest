using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplication9.Context;
using WebApplication9.Models;
using WebApplication9.Models.Abstraction;

namespace WebApplication9.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        private readonly AppDbContext _context;
        private DbSet<T> Entity;
        public Repository(AppDbContext context)
        {
            _context = context;
            Entity = context.Set<T>();
        }

        public async Task AddAsync(T entity, bool isLog = true)
        {
           await Entity.AddAsync(entity);

            if(isLog) { 
            MyLog log = new()
            {
                Data = JsonConvert.SerializeObject(entity),
                Progress = "Create",
                UserId = "1"
            };

            await _context.Set<MyLog>().AddAsync(log);
            }
        }

        public async Task RemoeById(int id)
        {
            T entity = await Entity.FindAsync(id);
            Entity.Remove(entity);

            MyLog log = new()
            {
                Data = JsonConvert.SerializeObject(entity),
                Progress = "Remove",
                UserId = "1"
            };

            await _context.Set<MyLog>().AddAsync(log);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
