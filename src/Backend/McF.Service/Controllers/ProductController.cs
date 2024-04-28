using McF.Process.DTO;
using McF.Process.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace McF.Process.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ProductTypeDTO> result = await mediator.Send(new GetAllProductTypesQuery()).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
