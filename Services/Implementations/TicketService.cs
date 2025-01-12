using AirlineBookingWebApi.AutoMapper.Interface;
using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Models.Entities;
using AirlineBookingWebApi.Repositories.Interfaces;
using AirlineBookingWebApi.Services.Interfaces;

namespace AirlineBookingWebApi.Services.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public TicketService(IHttpContextAccessor contextAccessor, ITicketRepository ticketRepository, IMapper mapper)
        {
            _contextAccessor = contextAccessor;
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task AddTicketAsync(TicketDTO ticketDTO)
        {
            var map=_mapper.Map<Ticket,TicketDTO>(ticketDTO); 
            await _ticketRepository.CreateAsync(map);
        }

        public async Task DeleteTicketAsync(Guid ticketId)
        {
            await _ticketRepository.DeleteAsync(ticketId);  
        }

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }

        public async Task<Ticket> GetTicketAsync(Guid ticketId)
        {
            return await GetTicketAsync(ticketId);
        }

        public async Task UpdateTicketAsync(UpdateTicketDTO updateTicketDTO)
        {
            var ticket=await _ticketRepository.GetByIdAsync(updateTicketDTO.Id);
            if (ticket == null) throw new Exception("Not found.");

            var map=_mapper.Map<Ticket,UpdateTicketDTO>(ticket); //!!!!!!!!!!!!!
            await _ticketRepository.UpdateAsync(map);
        }
    }
}
