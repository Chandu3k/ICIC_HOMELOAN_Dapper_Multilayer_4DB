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

    public class HotelManagementController : ControllerBase
    {
        private readonly IHotelsServices _service;
        private readonly ILoggingFactory _logger;

        public HotelManagementController(
            IHotelsServices service,
            ILoggingFactory logging)
        {
            _service = service;
            _logger = logging;
        }

        [HttpGet]
        [Route("GetAllHotels")]
        public async Task<IActionResult> GetAllHotels()
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";
            Log.Information($"HotelsController: GetAllHotels Api method Excution Starts and Current Loggedin username:{userName}");

            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Information", MessageTemplate = "GetAllHotels API called" });


            var result = await _service.GetAllHotels();

            if (result == null || !result.Any())
            {
                Log.Warning("No hotels found");
                await _logger.AddLoggingMessagesAsync(new ProjectLevelLog{UserName = userName,LogLevel = "Warning",MessageTemplate = "No hotels found"});
                return NotFound("Hotels data not found");
            }

            Log.Information("Hotels fetched successfully");
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog{UserName = userName,LogLevel = "Information",MessageTemplate = "Hotels fetched successfully"});

            return Ok(result);
        }

        [HttpGet]
        [Route("GetHotelById/{id}")]
        public async Task<IActionResult> GetAllHotelsById(int id)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";
            Log.Information($"HotelsController: GetHotelById Api method Excution Starts and Current Loggedin username:{userName}");
            Log.Information("GetHotelById API called with Id: {HotelId}", id);

            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Information", MessageTemplate = $"HotelsController: GetHotelById Api method Excution Starts" });
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog{UserName = userName,LogLevel = "Information",MessageTemplate = $"GetHotelById API called with Id: {id}"});

            var result = await _service.GetHotelById(id);

            if (result == null)
            {
                Log.Warning("Hotel not found for Id: {HotelId}", id);
                await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Warning", MessageTemplate = $"Hotel not found for Id: {id}" });

                return NotFound($"Hotel with Id:{id} not found");
            }
            Log.Information("Hotel fetched successfully for Id: {HotelId}", id);
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Information", MessageTemplate = $"Hotel fetched successfully for Id: {id}" });
            return Ok(result);
        }

        [HttpPost]
        [Route("AddHotel")]
        public async Task<IActionResult> AddHotel([FromBody] HotelsDto hotel)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";
            Log.Information($"HotelsController: AddHotel Api method Excution Starts and Current Loggedin username:{userName}");
            Log.Information("AddHotel API called for Hotel: {HotelName}", hotel.HotelName);
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Information", MessageTemplate = $"HotelsController: AddHotel Api method Excution Starts" });
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Information", MessageTemplate = $"AddHotel API called for Hotel: {hotel.HotelName}" });

            var result = await _service.AddHotels(hotel);

            Log.Information("Hotel added successfully");
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = "Chandu", LogLevel = "Information", MessageTemplate = "Hotel added successfully" });

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPut]
        [Route("UpdateHotel")]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelsDto hotel)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";
            Log.Information($"HotelsController: UpdateHotel Api method Excution Starts and Current Loggedin username:{userName}");
            Log.Information("UpdateHotel API called for Hotel Id: {HotelId}", hotel.Id);
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Information", MessageTemplate = $"HotelsController: UpdateHotel Api method Excution Starts" });
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Information", MessageTemplate = $"UpdateHotel API called for Hotel Id: {hotel.Id}" });

            var result = await _service.UpdateHotel(hotel);

            if (result == null)
            {
                Log.Warning("Hotel not found for update. Id: {HotelId}", hotel.Id);
                await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Warning", MessageTemplate = $"Hotel not found for update. Id: {hotel.Id}" });

                return NotFound($"Hotel with Id:{hotel.Id} not found");
            }

            Log.Information("Hotel updated successfully");
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Information", MessageTemplate = "Hotel updated successfully" });

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteHotel/{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var userName = User?.FindFirst("UserName")?.Value ?? "Chandu";
            Log.Information($"HotelsController: DeleteHotel Api method Excution Starts and Current Loggedin username:{userName}");
            Log.Information("DeleteHotel API called for Hotel Id: {HotelId}", id);
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Information", MessageTemplate = $"HotelsController: DeleteHotel Api method Excution Starts" });
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Information", MessageTemplate = $"DeleteHotel API called for Hotel Id: {id}" });


            var result = await _service.DeleteHotelById(id);

            if (result == null)
            {
                Log.Warning("Hotel not found for deletion. Id: {HotelId}", id);
                await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Warning", MessageTemplate = $"Hotel not found for deletion. Id: {id}" });

                return NotFound($"Hotel with Id:{id} not found");
            }

            Log.Information("Hotel deleted successfully");
            await _logger.AddLoggingMessagesAsync(new ProjectLevelLog { UserName = userName, LogLevel = "Information", MessageTemplate = "Hotel deleted successfully" });

            return Ok(result);
        }
    }
}