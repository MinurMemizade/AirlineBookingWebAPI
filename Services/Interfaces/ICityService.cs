using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Models.Entities;

namespace AirlineBookingWebApi.Services.Interfaces
{
    public interface ICityService
    {
        Task<List<City>> GetAllCities();
        Task<City> GetCityById(Guid id);
        Task AddCity(CityDTO cityDTO);
        Task DeleteCity(Guid id);
        Task UpdateCity(UpdateCityDTO updateCityDTO);
    }
}
