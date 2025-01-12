using AirlineBookingWebApi.Models.Common;
using AirlineBookingWebApi.Models.Identity;

namespace AirlineBookingWebApi.Models.Entities
{
    public class Ticket : BaseEntity
    {
        public Guid OutboundFlightId { get; set; }
        public FligthDate OutboundFlight {  get; set; }
        public Guid? ReturnFlightId { get; set; }
        public FligthDate? ReturnFlight { get; set; }
        public Guid PassengerId { get; set; }
        public AppUser Passenger { get; set; }
        public int TotalPasssengers { get; set; }
        public double TotalPrice { get; set; }
    }
}
