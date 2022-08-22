using ServiceRepositoryPattern.Models;

namespace ServiceRepositoryPattern.Repository
{
    public interface IFoodRepository
    {
        List<FoodItem> GetAllSold();
    }
}
