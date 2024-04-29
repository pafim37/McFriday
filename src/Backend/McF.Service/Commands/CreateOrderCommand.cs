using McF.Service.DTO;
using MediatR;

namespace McF.Service.Commands
{
    public record CreateOrderCommand(CartDTO CartDTO) : IRequest<int>;
}
