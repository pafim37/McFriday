﻿using McF.Process.Context;
using McF.Process.DAL;
using McF.Process.Models;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<ProductType> products = await repository.GetAllProductTypes().ConfigureAwait(false);
            return Ok(products);
        }
    }
}
