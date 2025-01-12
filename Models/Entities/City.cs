using AirlineBookingWebApi.Models.Common;

namespace AirlineBookingWebApi.Models.Entities
{
    public class City:BaseEntity
    {
        public Guid CountryId { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
    }
}
