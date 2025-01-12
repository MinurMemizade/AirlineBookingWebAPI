using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Models.Entities;

namespace AirlineBookingWebApi.Services.Interfaces
{
    public interface IFLightDateService
    {
        Task<List<FligthDate>> GetFligthDateListAsync();
        Task<FligthDate> GetFligthDateByIdAsync(Guid Id);
        Task AddFlightDate(FlightDateDTO flightDate);
        Task UpdateFlightDate(UpdateFlightDateDTO UpdateFlightDate);
        Task DeleteFlightDate(Guid Id);
    }
}
