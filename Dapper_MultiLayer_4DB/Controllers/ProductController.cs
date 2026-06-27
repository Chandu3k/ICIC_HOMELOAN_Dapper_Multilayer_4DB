using BussinessEntites.Dtos;
using BussinessEntites.Interfaces.ILogs;
using BussinessEntites.Interfaces.IServices;
using BussinessEntites.Models.ModelLogs;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ICICBank_HomeLoan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILoggingFactory _logger;

        public ProductController(
            IProductService service,
            ILoggingFactory logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information($"ProductController: GetAllProducts API method Execution Starts. User: {userName}");

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "GetAllProducts API called"
                });

            var result = await _service.GetAllProductsAsync();

            if (result == null || !result.Any())
            {
                Log.Warning("No products found");

                await _logger.AddLoggingMessagesAsync(
                    new ProjectLevelLog
                    {
                        UserName = userName,
                        LogLevel = "Warning",
                        MessageTemplate = "No products found"
                    });

                return NotFound("Products data not found");
            }

            Log.Information("Products fetched successfully");

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "Products fetched successfully"
                });

            return Ok(result);
        }

        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information("GetProductById API called with Id: {ProductId}", id);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"GetProductById API called with Id: {id}"
                });

            var result = await _service.GetProductByIdAsync(id);

            if (result == null)
            {
                Log.Warning("Product not found for Id: {ProductId}", id);

                await _logger.AddLoggingMessagesAsync(
                    new ProjectLevelLog
                    {
                        UserName = userName,
                        LogLevel = "Warning",
                        MessageTemplate = $"Product not found for Id: {id}"
                    });

                return NotFound($"Product with Id:{id} not found");
            }

            Log.Information("Product fetched successfully for Id: {ProductId}", id);

            return Ok(result);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto product)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information("AddProduct API called for Product: {ProductName}", product.ProductName);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"AddProduct API called for Product: {product.ProductName}"
                });

            var result = await _service.AddProductAsync(product);

            Log.Information("Product added successfully");

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "Product added successfully"
                });

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto product)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information("UpdateProduct API called for Product Id: {ProductId}", product.ProductId);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"UpdateProduct API called for Product Id: {product.ProductId}"
                });

            var result = await _service.UpdateProductAsync(product);

            if (result == null)
            {
                Log.Warning("Product not found for update. Id: {ProductId}", product.ProductId);

                await _logger.AddLoggingMessagesAsync(
                    new ProjectLevelLog
                    {
                        UserName = userName,
                        LogLevel = "Warning",
                        MessageTemplate = $"Product not found for update. Id: {product.ProductId}"
                    });

                return NotFound($"Product with Id:{product.ProductId} not found");
            }

            Log.Information("Product updated successfully");

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "Product updated successfully"
                });

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information("DeleteProduct API called for Product Id: {ProductId}", id);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"DeleteProduct API called for Product Id: {id}"
                });

            var result = await _service.DeleteProductAsync(id);

            if (result == null)
            {
                Log.Warning("Product not found for deletion. Id: {ProductId}", id);

                await _logger.AddLoggingMessagesAsync(
                    new ProjectLevelLog
                    {
                        UserName = userName,
                        LogLevel = "Warning",
                        MessageTemplate = $"Product not found for deletion. Id: {id}"
                    });

                return NotFound($"Product with Id:{id} not found");
            }

            Log.Information("Product deleted successfully");

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "Product deleted successfully"
                });

            return Ok(result);
        }
    }
}