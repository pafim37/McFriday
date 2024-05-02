using McF.Service.Context;
using McF.Service.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McF.Service.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypes()
        {
            return await context.ProductTypes.Include(p => p.Products).ToListAsync();
        }
    }
}
