using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAllCities()
        {
           var result=await _cityService.GetAllCities();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetCityById/{id}")]
        public async Task<IActionResult> GetCityById(Guid id)
        {
            var result=await _cityService.GetCityById(id);
            return StatusCode(StatusCodes.Status200OK,result);
        }

        [HttpPost("AddCity")]
        public async Task<IActionResult> AddCity([FromForm] CityDTO cityDTO)
        {
            await _cityService.AddCity(cityDTO);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpPut("UpdateCity")]
        public async Task<IActionResult> UpdateCity([FromForm] UpdateCityDTO updateCityDTO)
        {
            await _cityService.UpdateCity(updateCityDTO);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpDelete("DeleteCity")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            await _cityService.DeleteCity(id);
            return StatusCode(StatusCodes.Status202Accepted, null);
        }
    }
}
