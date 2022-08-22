using ServiceRepositoryPattern.Models;
using ServiceRepositoryPattern.Repository;

namespace ServiceRepositoryPattern.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepo;
        private readonly ILogger<FoodService> _logger;

        public FoodService(IFoodRepository foodRepo,ILogger<FoodService> logger)
        {
            _foodRepo = foodRepo;
            _logger = logger;
        }

        public List<FoodItem> GetAllSold()
        {
            _logger.LogCritical("Food Service Get All Sold Method Called");
            return _foodRepo.GetAllSold();
            
        }
    }
}
