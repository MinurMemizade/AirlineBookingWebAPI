using AirlineBookingWebApi.Models.Entities;

namespace AirlineBookingWebApi.Models.DTOs
{
    public class FlightDateDTO
    {
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Guid FromLocationId { get; set; }
        public Guid ToDestinationId { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
    }

    public class UpdateFlightDateDTO
    {
        public Guid Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Guid FromLocationId { get; set; }
        public Guid ToDestinationId { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
    }
}
