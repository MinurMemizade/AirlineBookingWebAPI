using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightDateController : ControllerBase
    {
        private readonly IFLightDateService _fLightDateService;

        public FlightDateController(IFLightDateService fLightDateService)
        {
            _fLightDateService = fLightDateService;
        }

        [HttpGet("GetAllDates")]
        public async Task<IActionResult> GetAllFlightDates()
        {
            var result=await _fLightDateService.GetFligthDateListAsync();
            return StatusCode(StatusCodes.Status200OK, result); 
        }

        [HttpGet("GetDatesById")]
        public async Task<IActionResult> GetFlightDateById(Guid id)
        {
            var result=await _fLightDateService.GetFligthDateByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK,result);
        }

        [HttpPost("AddDate")]
        public async Task<IActionResult> AddFlightDate([FromForm] FlightDateDTO flightDateDTO)
        {
            await _fLightDateService.AddFlightDate(flightDateDTO);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("UpdateDate")]
        public async Task<IActionResult> UpdateDate([FromForm] UpdateFlightDateDTO flightDateDTO)
        {
            await _fLightDateService.UpdateFlightDate(flightDateDTO);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpDelete("DeleteDate")]
        public async Task<IActionResult> DeleteDate(Guid Id)
        {
            await _fLightDateService.DeleteFlightDate(Id);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
