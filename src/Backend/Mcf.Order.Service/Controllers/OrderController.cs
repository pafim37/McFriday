using Mcf.Order.Service.Commands;
using Mcf.Order.Service.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mcf.Order.Service.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("/")]
        public async Task<IActionResult> CreateOrder([FromBody] CartDTO cart)
        {
            int orderNumber = await mediator.Send(new CreateOrderCommand(cart)).ConfigureAwait(false);
            return Created("/", orderNumber);
        }
    }
}
