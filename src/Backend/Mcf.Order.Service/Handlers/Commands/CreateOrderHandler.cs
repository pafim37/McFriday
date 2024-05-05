using AutoMapper;
using Mcf.Order.Service.Commands;
using Mcf.Order.Service.DAL;
using Mcf.Order.Service.Generators;
using Mcf.Order.Service.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Mcf.Order.Service.Handlers.Commands
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public CreateOrderHandler(IOrderRepository repository, IMapper mapper, ILogger<CreateOrderHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Start handling request {typeof(request)}", request);
            CartEntity cart = mapper.Map<CartEntity>(request.CartDTO);
            cart.Status = Models.Primitives.OrderStatus.InProgress;
            int customerId = GeneratorId.GetNext();
            cart.CustomerId = customerId;
            await repository.CreateOrder(cart).ConfigureAwait(false);
            logger.LogInformation("End handling request {typeof(request)}", request);
            return customerId;
        }
    }
}
