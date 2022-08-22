using Microsoft.AspNetCore.Mvc;
using ServiceRepositoryPattern.Services;

namespace ServiceRepositoryPattern.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly ILogger<FoodController> _logger;

        public FoodController(IFoodService foodService,ILogger<FoodController> logger)
        {
            _logger = logger;
            _foodService = foodService;
        }
        
        public IActionResult Index()
        {
            _logger.LogWarning("\n\nFood Controller running at: {time}", DateTimeOffset.UtcNow);
            var itemsSold = _foodService.GetAllSold();
            return View(itemsSold);
        }
    }
}
