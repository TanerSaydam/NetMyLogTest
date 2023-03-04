using WebApplication9.Context;
using WebApplication9.Models;

namespace WebApplication9.Repositories
{
    public sealed class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
