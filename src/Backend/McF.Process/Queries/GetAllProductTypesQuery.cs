using McF.Process.Models;
using MediatR;

namespace McF.Process.Queries
{
    public record GetAllProductTypesQuery() : IRequest<IEnumerable<ProductType>>;
}
