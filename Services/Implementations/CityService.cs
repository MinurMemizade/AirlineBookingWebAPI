using AirlineBookingWebApi.AutoMapper.Interface;
using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Models.Entities;
using AirlineBookingWebApi.Repositories.Interfaces;
using AirlineBookingWebApi.Services.Interfaces;

namespace AirlineBookingWebApi.Services.Implementations
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(IMapper mapper, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public async Task AddCity(CityDTO cityDTO)
        {
            var map = _mapper.Map<City,CityDTO>(cityDTO);
            await _cityRepository.CreateAsync(map);
        }

        public async Task DeleteCity(Guid id)
        {
            await _cityRepository.DeleteAsync(id);
        }

        public Task<List<City>> GetAllCities()
        {
            return _cityRepository.GetAllAsync();
        }

        public async Task<City> GetCityById(Guid id)
        {
            return await _cityRepository.GetByIdAsync(id);
        }

        public async Task UpdateCity(UpdateCityDTO updateCityDTO)
        {
            var city = await _cityRepository.GetByIdAsync(updateCityDTO.Id);
            if (city == null) throw new Exception("City not found.");
            
            city.CityName = updateCityDTO.CityName;
            await _cityRepository.UpdateAsync(city);
        }
    }
}
