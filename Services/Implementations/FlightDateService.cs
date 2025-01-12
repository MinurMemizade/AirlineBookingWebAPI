using AirlineBookingWebApi.AutoMapper.Interface;
using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Models.Entities;
using AirlineBookingWebApi.Repositories.Interfaces;
using AirlineBookingWebApi.Services.Interfaces;

namespace AirlineBookingWebApi.Services.Implementations
{
    public class FlightDateService : IFLightDateService
    {
        private readonly IFlightDateRepository _flightDateRepository;
        private readonly IMapper _mapper;

        public FlightDateService(IFlightDateRepository flightDateRepository, IMapper mapper)
        {
            _flightDateRepository = flightDateRepository;
            _mapper = mapper;
        }

        public async Task AddFlightDate(FlightDateDTO flightDate)
        {
            var map=_mapper.Map<FligthDate,FlightDateDTO>(flightDate);
            await _flightDateRepository.CreateAsync(map);
        }

        public async Task DeleteFlightDate(Guid Id)
        {
            await _flightDateRepository.DeleteAsync(Id);
        }

        public async Task<FligthDate> GetFligthDateByIdAsync(Guid Id)
        {
            return await _flightDateRepository.GetByIdAsync(Id);
        }

        public async Task<List<FligthDate>> GetFligthDateListAsync()
        {
            return await _flightDateRepository.GetAllAsync();
        }

        public async Task UpdateFlightDate(UpdateFlightDateDTO updateFlightDate)
        {
            var date=await _flightDateRepository.GetByIdAsync(updateFlightDate.Id);
            if (date == null) throw new Exception("Not found.");

            date.Duration = updateFlightDate.Duration;
            date.Price = updateFlightDate.Price;
            date.ArrivalTime = updateFlightDate.ArrivalTime;
            date.DepartureTime = updateFlightDate.DepartureTime;
            date.FromLocationId = updateFlightDate.FromLocationId;
            date.ToDestinationId = updateFlightDate.ToDestinationId;
            await _flightDateRepository.UpdateAsync(date);
        }
    }
}
