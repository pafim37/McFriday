using Mcf.Order.Service.Models;
using System.Threading.Tasks;

namespace Mcf.Order.Service.DAL
{
    public interface IOrderRepository
    {
        public Task CreateOrder(Cart cart);
    }
}
