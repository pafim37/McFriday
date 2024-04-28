using McF.Process.Models;

namespace McF.Process.DAL
{
    public interface IRepository
    {
        public Task<IEnumerable<ProductType>> GetAllProductTypes();
    }
}
