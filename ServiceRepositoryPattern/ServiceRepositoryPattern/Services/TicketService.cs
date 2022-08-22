using ServiceRepositoryPattern.Models;
using ServiceRepositoryPattern.Repository;

namespace ServiceRepositoryPattern.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepo;
        private readonly ILogger<TicketService> _logger;

        public TicketService(ITicketRepository ticketRepo, ILogger<TicketService> logger)
        {
            _ticketRepo = ticketRepo;
            _logger = logger;
        }

        public List<Ticket> GetAllSold()
        {
            _logger.LogTrace("\nTicket Service Get All Sold Method Called!!\n");
            return _ticketRepo.GetAllSold();
        }
    }
}
