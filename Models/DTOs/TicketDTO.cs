using AirlineBookingWebApi.Models.Entities;
using AirlineBookingWebApi.Models.Identity;

namespace AirlineBookingWebApi.Models.DTOs
{
    public class TicketDTO
    {
        public Guid OutboundFlightId { get; set; }
        public Guid? ReturnFlightId { get; set; }
        public Guid PassengerId { get; set; }
        public int TotalPassenger {  get; set; }
        public double TotalPrice { get; set; }
    }

    public class UpdateTicketDTO
    {
        public Guid Id { get; set; }
        public Guid OutboundFlightId { get; set; }
        public Guid? ReturnFlightId { get; set; }
        public Guid PassengerId { get; set; }
        public int TotalPassenger { get; set; }
        public double TotalPrice { get; set; }
    }
}
