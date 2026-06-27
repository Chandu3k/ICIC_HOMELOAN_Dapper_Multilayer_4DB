using BussinessEntites.Interfaces;
using BussinessEntites.Interfaces.IRepository;
using BussinessEntites.Models;
using BussinessEntites.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ProductRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddProductAsync(Product product)
        {
            using (IDbConnection connection = _connectionFactory.ProductConnectionString())
            {
                DynamicParameters parma = new DynamicParameters();
                parma.Add(SP_Parameters.ProductName, product.ProductName);
                parma.Add(SP_Parameters.ProductPrice, product.ProductPrice);
                parma.Add(SP_Parameters.Product_IsActive, product.Product_IsActive);
                parma.Add(SP_Parameters.Product_InsertedValue, dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync(SP_Names.AddProduct, parma, commandType: CommandType.StoredProcedure);
                int insertedId = parma.Get<int>(SP_Parameters.Product_InsertedValue);
                return insertedId;
            }
        }

        public async Task<string> DeleteProductAsync(int productId)
        {
            using (IDbConnection connection = _connectionFactory.ProductConnectionString())
            {
                DynamicParameters parma = new DynamicParameters();
                parma.Add(SP_Parameters.ProductId, productId);
                var result = await connection.QueryAsync<Product>(SP_Names.GetProductById, parma, commandType: CommandType.StoredProcedure);
                Product pro = result.FirstOrDefault();

                if (pro == null)
                {
                    return $"No product found with the given ID:{productId}.";
                }
                else
                {
                    string DeletedData = $"Deleted Product Details: ID: {pro.ProductId}, Name: {pro.ProductName}, Price: {pro.ProductPrice}, IsActive: {pro.Product_IsActive}";
                    await connection.ExecuteAsync(SP_Names.DeleteProduct, parma, commandType: CommandType.StoredProcedure);
                    return DeletedData;
                }
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            using (IDbConnection connection = _connectionFactory.ProductConnectionString())
            {
                var result = await connection.QueryAsync<Product>(SP_Names.GetProducts, commandType: CommandType.StoredProcedure);
                List<Product> pro = result.ToList();
                return pro;
            }
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            using (IDbConnection connection = _connectionFactory.ProductConnectionString())
            {
                DynamicParameters parma = new DynamicParameters();
                parma.Add(SP_Parameters.ProductId, productId);
                var result = await connection.QueryAsync<Product>(SP_Names.GetProductById, parma, commandType: CommandType.StoredProcedure);
                Product pro = result.FirstOrDefault();
                return pro;
            }
        }

        public async Task<string> UpdateProductAsync(Product product)
        {
            using (IDbConnection connection = _connectionFactory.ProductConnectionString())
            {
                DynamicParameters parma = new DynamicParameters();
                parma.Add(SP_Parameters.ProductId, product.ProductId);
                var result = await connection.QueryAsync<Product>(SP_Names.GetProductById, parma, commandType: CommandType.StoredProcedure);
                Product pro = result.FirstOrDefault();
                if (pro == null)
                {
                    return $"No product found with the given ID:{product.ProductId}";
                }
                else
                {
                    parma.Add(SP_Parameters.ProductName, product.ProductName);
                    parma.Add(SP_Parameters.ProductPrice, product.ProductPrice);
                    parma.Add(SP_Parameters.Product_IsActive, product.Product_IsActive);
                    parma.Add(SP_Parameters.Product_RowCount, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    
                    await connection.ExecuteAsync(SP_Names.UpdateProduct, parma, commandType: CommandType.StoredProcedure);
                    var updatedRow = parma.Get<int>(SP_Parameters.Product_RowCount);
                    return updatedRow>0? $"Product with ID:{product.ProductId} has been updated successfully.": $"Failed to update product with ID:{product.ProductId}.";
                }
            }
        }
    }
}
