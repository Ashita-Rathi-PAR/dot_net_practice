using ServiceRepositoryPattern.Models;

namespace ServiceRepositoryPattern.Services
{
    public interface IFoodService
    {
        List<FoodItem> GetAllSold();
    }
}
