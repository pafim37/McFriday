using McF.Product.Service.DTO;
using McF.Product.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McF.Product.Service.Controllers
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
