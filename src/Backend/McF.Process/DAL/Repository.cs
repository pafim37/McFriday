using McF.Process.Context;
using McF.Process.Models;
using Microsoft.EntityFrameworkCore;

namespace McF.Process.DAL
{
    public class Repository : IRepository
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypes()
        {
            return await context.ProductTypes.Include(p => p.Products).ToListAsync();
        }
    }
}
