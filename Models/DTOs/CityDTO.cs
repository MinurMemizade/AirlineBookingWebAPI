using AirlineBookingWebApi.Models.Entities;

namespace AirlineBookingWebApi.Models.DTOs
{
    public class CityDTO
    {
        public string CityName { get; set; }
        public Guid CountryId { get; set; }
    }

    public class UpdateCityDTO
    {
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public Guid CountryId { get; set; }
    }
}
