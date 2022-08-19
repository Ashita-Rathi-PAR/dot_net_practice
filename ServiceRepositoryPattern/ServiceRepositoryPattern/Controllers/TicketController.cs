using Microsoft.AspNetCore.Mvc;
using ServiceRepositoryPattern.Services;

namespace ServiceRepositoryPattern.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ILogger<FoodController> _logger;

        public TicketController(ITicketService ticketService, ILogger<FoodController> logger)
        {
            _ticketService = ticketService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogDebug("\n\nTicket Controller running at: {time}", DateTimeOffset.UtcNow);
            var tickets = _ticketService.GetAllSold();
            return View(tickets);
        }
    }
}
