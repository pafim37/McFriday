using McF.Product.Service.Context;
using McF.Product.Service.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McF.Product.Service.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypes()
        {
            return await context.ProductTypes.Include(p => p.Products).ToListAsync();
        }
    }
}
