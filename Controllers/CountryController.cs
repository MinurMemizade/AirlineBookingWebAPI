using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Services.Implementations;
using AirlineBookingWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await _countryService.GetAllCountries();
            return StatusCode(StatusCodes.Status200OK,result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetCountriesById(Guid id)
        {
            var result=await _countryService.GetCountry(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddNewCountry")]
        public async Task<IActionResult> AddCountry([FromForm]CountryDTO countryDTO)
        {
            await _countryService.AddCountry(countryDTO);
            return StatusCode(StatusCodes.Status201Created, countryDTO);
        }

        [HttpDelete("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            await _countryService.DeleteCountry(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
