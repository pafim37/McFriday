using AutoMapper;
using McF.Process.DAL;
using McF.Process.DTO;
using McF.Process.Models;
using McF.Process.Queries;
using MediatR;

namespace McF.Process.Handlers
{
    public class GetAllProductTypesHandler : IRequestHandler<GetAllProductTypesQuery, IEnumerable<DTO.ProductTypeDTO>>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public GetAllProductTypesHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ProductTypeDTO>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ProductType> productTypes = await repository.GetAllProductTypes().ConfigureAwait(false);
            return mapper.Map<IEnumerable<ProductTypeDTO>>(productTypes);
        }
    }
}
