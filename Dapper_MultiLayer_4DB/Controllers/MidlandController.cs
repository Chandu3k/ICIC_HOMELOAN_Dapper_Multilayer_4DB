using BussinessEntites.Dtos;
using BussinessEntites.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ICICBank_HomeLoan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MidlandController : ControllerBase
    {
        private readonly IMidlandService _service;
        public MidlandController(IMidlandService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllMidlandItems")]
        public async Task<IActionResult> GetAllMidlandItems()
        {
            try
            {
                var result = await _service.GetMidlandItemAsync();
                if (result == null || !result.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Midland items not found");
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
        [Route("GetMidlandItemById/{id}")]
        public async Task<IActionResult> GetMidlandItemById(int id)
        {
            try
            {
                var result = await _service.GetMidlandItemByIdAsync(id);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Midland item with Id:{id} not found");
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
        [Route("AddMidlandItem")]
        public async Task<IActionResult> AddMidlandItem([FromBody] MidlandItemsDto midlandItem)
        {
            try
            {
                var result = await _service.AddMidlandItemAsync(midlandItem);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateMidlandItem")]
        public async Task<IActionResult> UpdateMidlandItem([FromBody] MidlandItemsDto midlandItem)
        {
            try
            {
                var result = await _service.UpdateMidlandItemAsync(midlandItem);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Midland item with Id:{midlandItem.Id} not found");
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
        [Route("DeleteMidlandItem/{id}")]
        public async Task<IActionResult> DeleteMidlandItem(int id)
        {
            try
            {
                var result = await _service.DeleteMidlandItemAsync(id);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Midland item with Id:{id} not found");
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
