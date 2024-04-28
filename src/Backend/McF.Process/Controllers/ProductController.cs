using McF.Process.DAL;
using McF.Process.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;

namespace McF.Process.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IRepository repository;

        public ProductController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ProductType> productTypes = await repository.GetAllProductTypes().ConfigureAwait(false);
            foreach (ProductType productType in productTypes) 
            {
                foreach (var product in productType.Products)
                {
                    if (product.ImageByteArray != null)
                    {
                        product.ImageBase64 = Convert.ToBase64String(product.ImageByteArray);
                    }
                }
            }
            return Ok(productTypes);
        }
    }
}
