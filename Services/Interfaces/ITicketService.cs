using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Models.Entities;

namespace AirlineBookingWebApi.Services.Interfaces
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllTicketsAsync();
        Task<Ticket> GetTicketAsync(Guid ticketId);
        Task AddTicketAsync(TicketDTO ticketDTO);
        Task DeleteTicketAsync(Guid ticketId);
        Task UpdateTicketAsync(UpdateTicketDTO updateTicketDTO);
    }
}
