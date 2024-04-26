using McF.Process.Context;
using McF.Process.Models;
using Microsoft.AspNetCore.Mvc;

namespace McF.Process.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private readonly AppDbContext dbContext;

        public HomeController(AppDbContext context)
        {
            dbContext = context;
        }
        [HttpGet()]
        [Route("/")]
        public IActionResult Get()
        {
            dbContext.Entities.Add(new Entity { Id = new Guid(), Name = "Home" });
            dbContext.SaveChanges();
            return Ok("Hello World");
        }
    }
}
