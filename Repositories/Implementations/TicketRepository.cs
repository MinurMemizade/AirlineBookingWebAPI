using AirlineBookingWebApi.Context;
using AirlineBookingWebApi.Models.Entities;
using AirlineBookingWebApi.Repositories.Interfaces;

namespace AirlineBookingWebApi.Repositories.Implementations
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
