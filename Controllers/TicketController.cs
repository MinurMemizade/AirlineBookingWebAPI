using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AirlineBookingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("GetAllTickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            var result = await _ticketService.GetAllTicketsAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetTicketById")]
        public async Task<IActionResult> GetTicketById(Guid id)
        {
            var result = await _ticketService.GetTicketAsync(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddTicket")]
        public async Task<IActionResult> AddTicket(TicketDTO ticketDTO)
        {
            await _ticketService.AddTicketAsync(ticketDTO);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("UpdateTicket")]
        public async Task<IActionResult> UpdateTicket(UpdateTicketDTO updateTicketDTO)
        {
            await _ticketService.UpdateTicketAsync(updateTicketDTO);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpDelete("DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(Guid id)
        {
            await _ticketService.DeleteTicketAsync(id);
            return StatusCode(StatusCodes.Status202Accepted, null);
        }
    }
}
