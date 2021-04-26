using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DatabaseServices
{
    public interface IProductTypeService
    {
        Task<bool> CreateProductType(ProductType request);
        Task<bool> DeleteProductType(Guid productTypeId);
        Task<IEnumerable<ProductType>> FetchProductType();
    }
}
