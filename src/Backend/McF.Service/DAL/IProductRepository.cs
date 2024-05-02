using McF.Product.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McF.Product.Service.DAL
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductType>> GetAllProductTypes();

    }
}
