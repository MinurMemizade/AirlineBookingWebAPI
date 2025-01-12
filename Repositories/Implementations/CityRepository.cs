using AirlineBookingWebApi.Context;
using AirlineBookingWebApi.Models.Entities;
using AirlineBookingWebApi.Repositories.Interfaces;

namespace AirlineBookingWebApi.Repositories.Implementations
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
