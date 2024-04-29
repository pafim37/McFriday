using AutoMapper;
using McF.Process.DAL;
using McF.Service.Commands;
using McF.Service.Generators;
using McF.Service.Handlers.Queries;
using McF.Service.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace McF.Service.Handlers.Commands
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public CreateOrderHandler(IRepository repository, IMapper mapper, ILogger<GetAllProductTypesHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Start handling request {typeof(request)}", request);
            Cart cart = mapper.Map<Cart>(request.CartDTO);
            cart.Status = Models.Primitives.OrderStatus.InProgress;
            int customerId = GeneratorId.GetNext();
            cart.CustomerId = customerId;
            await repository.CreateOrder(cart).ConfigureAwait(false);
            logger.LogInformation("End handling request {typeof(request)}", request);
            return customerId;
        }
    }
}
