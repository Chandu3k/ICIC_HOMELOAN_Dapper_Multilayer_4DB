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
    public class MidlandController : ControllerBase
    {
        private readonly IMidlandService _service;
        private readonly ILoggingFactory _logger;

        public MidlandController(
            IMidlandService service,
            ILoggingFactory logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllMidlandItems")]
        public async Task<IActionResult> GetAllMidlandItems()
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information($"MidlandController: GetAllMidlandItems API method Execution Starts and Current Loggedin username:{userName}");
            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "GetAllMidlandItems API called"
                });

            var result = await _service.GetMidlandItemAsync();

            if (result == null || !result.Any())
            {
                Log.Warning("No Midland items found");

                await _logger.AddLoggingMessagesAsync(
                    new ProjectLevelLog
                    {
                        UserName = userName,
                        LogLevel = "Warning",
                        MessageTemplate = "No Midland items found"
                    });

                return NotFound("Midland items not found");
            }

            Log.Information("Midland items fetched successfully");

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "Midland items fetched successfully"
                });

            return Ok(result);
        }

        [HttpGet]
        [Route("GetMidlandItemById/{id}")]
        public async Task<IActionResult> GetMidlandItemById(int id)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information($"MidlandController: GetMidlandItemById API method Execution Starts and Current Loggedin username:{userName}");
            Log.Information("GetMidlandItemById API called with Id: {ItemId}", id);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"GetMidlandItemById API called with Id: {id}"
                });

            var result = await _service.GetMidlandItemByIdAsync(id);

            if (result == null)
            {
                Log.Warning("Midland item not found for Id: {ItemId}", id);

                await _logger.AddLoggingMessagesAsync(
                    new ProjectLevelLog
                    {
                        UserName = userName,
                        LogLevel = "Warning",
                        MessageTemplate = $"Midland item not found for Id: {id}"
                    });

                return NotFound($"Midland item with Id:{id} not found");
            }

            Log.Information("Midland item fetched successfully for Id: {ItemId}", id);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"Midland item fetched successfully for Id: {id}"
                });

            return Ok(result);
        }

        [HttpPost]
        [Route("AddMidlandItem")]
        public async Task<IActionResult> AddMidlandItem([FromBody] MidlandItemsDto midlandItem)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information($"MidlandController: AddMidlandItem API method Execution Starts and Current Loggedin username:{userName}");
            Log.Information("AddMidlandItem API called for Item: {ItemName}", midlandItem.Name);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"AddMidlandItem API called for Item: {midlandItem.Name}"
                });

            var result = await _service.AddMidlandItemAsync(midlandItem);

            Log.Information("Midland item added successfully");

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "Midland item added successfully"
                });

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPut]
        [Route("UpdateMidlandItem")]
        public async Task<IActionResult> UpdateMidlandItem([FromBody] MidlandItemsDto midlandItem)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information($"MidlandController: UpdateMidlandItem API method Execution Starts and Current Loggedin username:{userName}");
            Log.Information("UpdateMidlandItem API called for Item Id: {ItemId}", midlandItem.Id);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"UpdateMidlandItem API called for Item Id: {midlandItem.Id}"
                });

            var result = await _service.UpdateMidlandItemAsync(midlandItem);

            if (result == null)
            {
                Log.Warning("Midland item not found for update. Id: {ItemId}", midlandItem.Id);

                await _logger.AddLoggingMessagesAsync(
                    new ProjectLevelLog
                    {
                        UserName = userName,
                        LogLevel = "Warning",
                        MessageTemplate = $"Midland item not found for update. Id: {midlandItem.Id}"
                    });

                return NotFound($"Midland item with Id:{midlandItem.Id} not found");
            }

            Log.Information("Midland item updated successfully");

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "Midland item updated successfully"
                });

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteMidlandItem/{id}")]
        public async Task<IActionResult> DeleteMidlandItem(int id)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";

            Log.Information($"MidlandController: DeleteMidlandItem API method Execution Starts and Current Loggedin username:{userName}");
            Log.Information("DeleteMidlandItem API called for Item Id: {ItemId}", id);

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = $"DeleteMidlandItem API called for Item Id: {id}"
                });

            var result = await _service.DeleteMidlandItemAsync(id);

            if (result == null)
            {
                Log.Warning("Midland item not found for deletion. Id: {ItemId}", id);

                await _logger.AddLoggingMessagesAsync(
                    new ProjectLevelLog
                    {
                        UserName = userName,
                        LogLevel = "Warning",
                        MessageTemplate = $"Midland item not found for deletion. Id: {id}"
                    });

                return NotFound($"Midland item with Id:{id} not found");
            }

            Log.Information("Midland item deleted successfully");

            await _logger.AddLoggingMessagesAsync(
                new ProjectLevelLog
                {
                    UserName = userName,
                    LogLevel = "Information",
                    MessageTemplate = "Midland item deleted successfully"
                });

            return Ok(result);
        }
    }
}