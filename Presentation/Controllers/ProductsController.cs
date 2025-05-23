﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Context;
using Services.Interfaces;
using Entities.DTO;
using Presentation.ActionFilters;
using Entities.RequestFeatures;
using Newtonsoft.Json;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogFilterAttribute))]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _context;

        public ProductsController(IServiceManager context)
        {
            _context = context;
        }
        
        // GET: api/Products
        [HttpHead]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProductDtoForList>>> GetProducts([FromQuery]ProductParameters p)
        {
           var x = await _context.ProductService.GetAllProducts(p,false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(x.mt));
            return Ok(x.booksDto);
        }
        [HttpGet("category")]
        public async Task<ActionResult<ProductDtoForList>> GetProductsForCategory([FromQuery]ProductParameters prdc)
        {
            var x = await _context.ProductService.GetProductsForCategorySearch(prdc);
            return Ok(x);
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDtoForList>> GetProducts(int id)
        {
            var x = await _context.ProductService.GetProductById(id,false);
            return Ok(x);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, ProductDtoForUpdate products)
        {
            await _context.ProductService.UpdateProductFromService(id, products);

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<ProductDtoForInsert>> PostProducts(ProductDtoForInsert products)
        {
            await _context.ProductService.AddProductFromService(products);

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            await _context.ProductService.DeleteProductFromService(id);

            return NoContent();
        }
        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", "GET,PUT,POST,DELETE,HEAD,OPTIONS");
            return Ok();
        }


    }
}
