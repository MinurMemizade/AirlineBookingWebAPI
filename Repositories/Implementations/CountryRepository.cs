using AirlineBookingWebApi.Context;
using AirlineBookingWebApi.Models.Entities;
using AirlineBookingWebApi.Repositories.Interfaces;

namespace AirlineBookingWebApi.Repositories.Implementations
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
