using BussinessEntites.Dtos;
using BussinessEntites.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ICICBank_HomeLoan.Controllers
{
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;
        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllRestaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            try
            {
                var result = await _service.GetAllRestaurant();
                if (result == null || !result.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Restaurants  data not  found");
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
                var result = await _service.GetRestaurantById(id);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Restaurant with Id:{id} not found");
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
        [Route("AddRestaurant")]
        public async Task<IActionResult> AddRestaurant([FromBody] RestaurantDto restaurent)
        {
            try
            {
                var result = await _service.AddRestaurant(restaurent);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateRestaurant")]
        public async Task<IActionResult> UpdateRestaurant([FromBody] RestaurantDto restaurant)
        {
            try
            {
                var result = await _service.UpdateRestaurant(restaurant);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Restaurant with Id:{restaurant.Id} not found");
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
                var result = await _service.DeleteRestaurant(id);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Restaurant with Id:{id} not found");
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
