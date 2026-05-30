using BussinessEntites.Dtos;
using BussinessEntites.Interfaces;
using BussinessEntites.Models;
using Microsoft.AspNetCore.Mvc;

namespace ICICBank_HomeLoan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelManagementController : ControllerBase
    {
        private readonly IHotelsServices _service;
        public HotelManagementController(IHotelsServices service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllHotels")]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                var result = await _service.GetAllHotels();
                if (result == null|| !result.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Hotels data not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("GetHotelById/{id}")]
        public async Task<IActionResult> GetAllHotelsById(int id)
        {
            try
            {
                var result = await _service.GetHotelById(id);
                if (result == null )
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Hotel with Id:{id} not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("AddHotel")]
        public async Task<IActionResult> AddHotel([FromBody] HotelsDto hotel)
        {
            try
            {
                var result = await _service.AddHotels(hotel);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateHotel")]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelsDto hotel)
        {
            try
            {
                var result = await _service.UpdateHotel(hotel);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Hotel with Id:{hotel.Id} not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteHotel/{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                var result = await _service.DeleteHotelById(id);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Hotel with Id:{id} not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
