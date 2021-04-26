using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        public ProductTypeController(IProductTypeService productTypeService )
        {
            _productTypeService = productTypeService;
        }

        // We can update search criteria later
        [HttpGet]
        public async Task<IEnumerable<ProductType>> Get()
        {
            var result = await _productTypeService.FetchProductType();
            return result;
        }

        //// GET api/ProductType/ProductTypeID
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductTypeDetailsResponseModel>> Get(Guid id)
        //{
        //    var query = new GetProductTypeDetailsQuery() { ProductTypeId = id };
        //    return await Mediator.Send(query);
        //}

        // POST
        [HttpPost]
        public async Task<ActionResult<bool>> Post(ProductType model)
        {
            var result = await _productTypeService.CreateProductType(model);
            return result;
        }

        //// PUT 
        //[HttpPut("{id}")]
        //public async Task<ActionResult<bool>> Put(Guid id, [FromBody]UpdateProductTypeCommand request)
        //{
        //    request.ProductTypeID = id;
        //    return await Mediator.Send(request);
        //}

        // DELETE 
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var result = await _productTypeService.DeleteProductType(id);
            return result;
        }
    }
}