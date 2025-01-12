using AirlineBookingWebApi.Context;
using AirlineBookingWebApi.Models.Entities;
using AirlineBookingWebApi.Repositories.Interfaces;

namespace AirlineBookingWebApi.Repositories.Implementations
{
    public class FlightDateRepository : Repository<FligthDate>, IFlightDateRepository
    {
        public FlightDateRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
