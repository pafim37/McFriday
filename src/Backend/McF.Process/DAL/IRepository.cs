using McF.Process.Models;

namespace McF.Process.DAL
{
    public interface IRepository
    {
        public Task<List<Product>> GetAllProducts();
    }
}
