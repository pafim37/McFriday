using McF.Process.Models;
using McF.Service.Models;

namespace McF.Process.DAL
{
    public interface IRepository
    {
        public Task<IEnumerable<ProductType>> GetAllProductTypes();
        public Task CreateOrder(Cart cart);
    }
}
