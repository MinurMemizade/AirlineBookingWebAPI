using AirlineBookingWebApi.Models.Common;

namespace AirlineBookingWebApi.Models.Entities
{
    public class FligthDate : BaseEntity
    {
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Guid FromLocationId { get; set; }
        public City FromLocation { get; set; }
        public Guid ToDestinationId { get; set; }
        public City ToDestination { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
    }
}
