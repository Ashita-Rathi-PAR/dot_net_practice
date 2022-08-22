using ServiceRepositoryPattern.Models;
using ServiceRepositoryPattern.Repository;

namespace ServiceRepositoryPattern.Services 
{
    public class FinancialsService : IFinancialsService
    {
        private readonly ITicketRepository _ticketRepo;
        private readonly IFoodRepository _foodRepo;
        private readonly ILogger<FinancialsService> _logger;

        public FinancialsService(ITicketRepository ticketRepo,
                                    IFoodRepository foodRepo,
                                    ILogger<FinancialsService> logger)
        {
            _ticketRepo = ticketRepo;
            _foodRepo = foodRepo;
            _logger = logger;
        }

        public FinancialStats GetStats()
        {
            _logger.LogDebug("\nFinancial Service Get Stats Methods Called\n");
            FinancialStats stats = new FinancialStats();
            var foodSold = _foodRepo.GetAllSold();
            var ticketsSold = _ticketRepo.GetAllSold();

            stats.AverageTicketProfit =
              ticketsSold.Sum(x => x.Profit) / ticketsSold.Sum(x => x.Quantity);
            stats.AverageFoodItemProfit =
              foodSold.Sum(x => x.Profit) / foodSold.Sum(x => x.Quantity);

            return stats;
        }
    }
}
