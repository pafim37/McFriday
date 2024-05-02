using McF.Service.DTO;
using MediatR;
using System.Collections.Generic;

namespace McF.Service.Queries
{
    public record GetAllProductTypesQuery() : IRequest<IEnumerable<ProductTypeDTO>>;
}
