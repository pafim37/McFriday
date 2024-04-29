using McF.Service.Commands;
using McF.Service.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace McF.Service.Controllers
{
    [ApiController]
    public class OrderController : Controller
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
