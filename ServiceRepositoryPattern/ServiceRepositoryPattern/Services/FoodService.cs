using ServiceRepositoryPattern.Models;
using ServiceRepositoryPattern.Repository;

namespace ServiceRepositoryPattern.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepo;

        public FoodService(IFoodRepository foodRepo)
        {
            _foodRepo = foodRepo;
        }

        public List<FoodItem> GetAllSold() => _foodRepo.GetAllSold();
    }
}
