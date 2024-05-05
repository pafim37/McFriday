using McF.Product.Service.DTO;
using MediatR;
using System.Collections.Generic;

namespace McF.Product.Service.Queries
{
    public record GetAllProductTypesQuery() : IRequest<IEnumerable<ProductTypeDTO>>;
}
