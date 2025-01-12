using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Models.Entities;

namespace AirlineBookingWebApi.Services.Interfaces
{
    public interface ICountryService
    {
        Task<Country> GetCountry(Guid countryId);
        Task<List<Country>> GetAllCountries();
        Task AddCountry(CountryDTO country);
        Task DeleteCountry(Guid countryId);
    }
}
