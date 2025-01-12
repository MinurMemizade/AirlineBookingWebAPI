using AirlineBookingWebApi.AutoMapper.Interface;
using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Models.Entities;
using AirlineBookingWebApi.Repositories.Implementations;
using AirlineBookingWebApi.Repositories.Interfaces;
using AirlineBookingWebApi.Services.Interfaces;

namespace AirlineBookingWebApi.Services.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task AddCountry(CountryDTO countryDTO)
        {
            var map=_mapper.Map<Country,CountryDTO>(countryDTO);
            await _countryRepository.CreateAsync(map);
        }

        public async Task DeleteCountry(Guid countryId)
        {
            await _countryRepository.DeleteAsync(countryId);
        }

        public async Task<List<Country>> GetAllCountries()
        {
            return await _countryRepository.GetAllAsync();
        }

        public async Task<Country> GetCountry(Guid countryId)
        {
            return await _countryRepository.GetByIdAsync(countryId);
        }
    }
}
