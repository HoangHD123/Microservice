using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.WebAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var result = await _productService.FetchProduct();
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> Post(Product model)
        {
            var result = await _productService.CreateProduct(model);
            return result;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var result = await _productService.DeleteProduct(id);
            return result;
        }
    }
}
