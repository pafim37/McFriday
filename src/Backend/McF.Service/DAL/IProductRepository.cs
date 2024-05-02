using McF.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McF.Service.DAL
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductType>> GetAllProductTypes();

    }
}
