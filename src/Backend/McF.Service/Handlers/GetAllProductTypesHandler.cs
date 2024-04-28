using AutoMapper;
using McF.Process.DAL;
using McF.Process.DTO;
using McF.Process.Models;
using McF.Process.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace McF.Process.Handlers
{
    public class GetAllProductTypesHandler : IRequestHandler<GetAllProductTypesQuery, IEnumerable<DTO.ProductTypeDTO>>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public GetAllProductTypesHandler(IRepository repository, IMapper mapper, ILogger<GetAllProductTypesHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<IEnumerable<ProductTypeDTO>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Start handling request {typeof(request)}", request);
            IEnumerable<ProductType> productTypes = await repository.GetAllProductTypes().ConfigureAwait(false);
            IEnumerable<ProductTypeDTO> result = mapper.Map<IEnumerable<ProductTypeDTO>>(productTypes);
            logger.LogInformation("End handling request {typeof(request)}", request);
            return result;
        }
    }
}
