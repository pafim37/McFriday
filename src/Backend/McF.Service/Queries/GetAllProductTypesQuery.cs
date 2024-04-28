using McF.Process.DTO;
using MediatR;

namespace McF.Process.Queries
{
    public record GetAllProductTypesQuery() : IRequest<IEnumerable<ProductTypeDTO>>;
}
