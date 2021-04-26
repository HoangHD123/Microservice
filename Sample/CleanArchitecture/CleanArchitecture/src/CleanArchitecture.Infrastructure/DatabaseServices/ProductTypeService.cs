using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using SqlKata.Execution;
using SqlKata.Compilers;

namespace CleanArchitecture.Infrastructure.DatabaseServices
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IDatabaseConnectionFactory _database;

        public ProductTypeService(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<bool> CreateProductType(ProductType request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            //if (!await IsProductTypeKeyUnique(db, request.Name, Guid.Empty))
            //    return false;

            var affectedRecords = await db.Query("ProductType").InsertAsync(new
            {
                ProductTypeID = Guid.NewGuid(),
                ProductTypeKey = request.ProductTypeKey,
                ProductTypeName = request.ProductTypeName,
                RecordStatus = request.RecordStatus,
                CreatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            });
            //var parameters = new
            //{
            //    Id = Guid.NewGuid(),
            //    Name = request.Name,
            //    RecordStatus = request.Status,
            //    CreatedDate = DateTime.UtcNow,
            //    UpdatedUser = Guid.NewGuid()
            //};
            //var affectedRecords = await conn.ExecuteAsync("INSERT INTO ProductType(ProductTypeID, ProductTypeKey, ProductTypeName, RecordStatus,CreatedDate, UpdatedUser) " +
            //    "VALUES(@ProductTypeID, @ProductTypeKey, @ProductTypeName, @RecordStatus, @CreatedDate, @UpdatedUser)",
            //    parameters);
            return affectedRecords > 0;
        }

        public async Task<bool> DeleteProductType(Guid productTypeId)
        {
            using var conn = await _database.CreateConnectionAsync();
            //var db = new QueryFactory(conn, new SqlServerCompiler());
            //var affectedRecord = await db.Query("ProductType").Where("ProductTypeID", "=", productTypeId).DeleteAsync();

            var parameters = new
            {
                ProductTypeID = productTypeId
            };
            var affectedRecords = await conn.ExecuteAsync("DELETE FROM ProductType where ProductTypeID = @ProductTypeID",
                parameters);
            return affectedRecords > 0;
        }

        public async Task<IEnumerable<ProductType>> FetchProductType()
        {
            using var conn = await _database.CreateConnectionAsync();
            //var db = new QueryFactory(conn, new SqlServerCompiler());
            //var result = db.Query("ProductType");
            //return await result.GetAsync<ProductTypeResponseModel>();

            var result = conn.Query<ProductType>("Select * from ProductType").ToList();
            return result;
        }

        private async Task<bool> IsProductTypeKeyUnique(QueryFactory db, string productTypeKey, Guid productTypeID)
        {
            var result = await db.Query("ProductType").Where("ProductTypeKey", "=", productTypeKey)
                .FirstOrDefaultAsync<ProductType>();

            if (result == null)
                return true;

            return result.ProductTypeID == productTypeID;
        }
    }
}
