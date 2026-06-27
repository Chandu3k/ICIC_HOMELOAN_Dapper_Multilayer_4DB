using BussinessEntites.Dtos;
using BussinessEntites.Interfaces.ILogs;
using BussinessEntites.Interfaces.IServices;
using BussinessEntites.Models.ModelLogs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ICICBank_HomeLoan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;
        private readonly ILoggingFactory _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RestaurantController(
            IRestaurantService service,
            ILoggingFactory logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("GetAllRestaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information($"RestaurantController: GetAllRestaurants API started. User: {userName}");

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "GetAllRestaurants API called"
                });

            var result = await _service.GetAllRestaurant();

            if (result == null || !result.Any())
            {
                Log.Warning("No restaurants found");

                await _logger.AddLoggingMessagesAsync(
                    new ProjectLevelLog
                    {
                        UserName = userName,
                        LogLevel = "Warning",
                        MessageTemplate = "No restaurants found"
                    });

                return NotFound("Restaurants data not found");
            }

            Log.Information("Restaurants fetched successfully");

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "Restaurants fetched successfully"
                });

            return Ok(result);
        }

        [HttpGet]
        [Route("GetRestaurantById/{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information("GetRestaurantById API called with Id: {RestaurantId}", id);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"GetRestaurantById API called with Id: {id}"
                });

            var result = await _service.GetRestaurantById(id);

            if (result == null)
            {
                Log.Warning("Restaurant not found for Id: {RestaurantId}", id);

                await _logger.AddLoggingMessagesAsync(
                    new ProjectLevelLog
                    {
                        UserName = userName,
                        LogLevel = "Warning",
                        MessageTemplate = $"Restaurant not found for Id: {id}"
                    });

                return NotFound($"Restaurant with Id:{id} not found");
            }

            Log.Information("Restaurant fetched successfully");

            return Ok(result);
        }

        [HttpPost]
        [Route("AddRestaurant")]
        public async Task<IActionResult> AddRestaurant([FromBody] RestaurantDto restaurant)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information("AddRestaurant API called for Restaurant: {RestaurantName}", restaurant.RestaurantName);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"AddRestaurant API called for Restaurant: {restaurant.RestaurantName}"
                });

            var result = await _service.AddRestaurant(restaurant);

            Log.Information("Restaurant added successfully");

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPut]
        [Route("UpdateRestaurant")]
        public async Task<IActionResult> UpdateRestaurant([FromBody] RestaurantDto restaurant)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information("UpdateRestaurant API called for Id: {RestaurantId}", restaurant.Id);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"UpdateRestaurant API called for Id: {restaurant.Id}"
                });

            var result = await _service.UpdateRestaurant(restaurant);

            if (result == null)
            {
                Log.Warning("Restaurant not found for update Id: {RestaurantId}", restaurant.Id);

                return NotFound($"Restaurant with Id:{restaurant.Id} not found");
            }

            Log.Information("Restaurant updated successfully");

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteRestaurant/{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information("DeleteRestaurant API called for Id: {RestaurantId}", id);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"DeleteRestaurant API called for Id: {id}"
                });

            var result = await _service.DeleteRestaurant(id);

            if (result == null)
            {
                Log.Warning("Restaurant not found for delete Id: {RestaurantId}", id);

                return NotFound($"Restaurant with Id:{id} not found");
            }

            Log.Information("Restaurant deleted successfully");

            return Ok(result);
        }
    }
}