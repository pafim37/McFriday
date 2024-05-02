using AutoMapper;
using McF.Service.DAL;
using McF.Service.DTO;
using McF.Service.Models;
using McF.Service.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace McF.Service.Handlers.Queries
{
    public class GetAllProductTypesHandler : IRequestHandler<GetAllProductTypesQuery, IEnumerable<ProductTypeDTO>>
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public GetAllProductTypesHandler(IProductRepository repository, IMapper mapper, ILogger<GetAllProductTypesHandler> logger)
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
