using AirlineBookingWebApi.Models.DTOs;

namespace AirlineBookingWebApi.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendVerificationEmail(string email);
    }
}
