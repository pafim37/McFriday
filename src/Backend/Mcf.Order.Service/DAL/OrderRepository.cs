using Mcf.Order.Service.Context;
using Mcf.Order.Service.Models;
using System.Threading.Tasks;
namespace Mcf.Order.Service.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext context;

        public OrderRepository(OrderContext context)
        {
            this.context = context;
        }
        public async Task CreateOrder(Cart cart)
        {
            await context.Carts.AddAsync(cart).ConfigureAwait(false);
            context.SaveChanges();
        }
    }
}
