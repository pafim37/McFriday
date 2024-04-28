using McF.Process.DAL;
using McF.Process.Models;
using McF.Process.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;

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
            var result = await mediator.Send(new GetAllProductTypesQuery()).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
