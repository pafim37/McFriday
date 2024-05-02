using Mcf.Order.Service.DTOs;
using MediatR;

namespace Mcf.Order.Service.Commands
{
    public record CreateOrderCommand(CartDTO CartDTO) : IRequest<int>;
}
