using ServiceRepositoryPattern.Models;
using ServiceRepositoryPattern.Repository;

namespace ServiceRepositoryPattern.Services
{
    public interface IFinancialsService
    {
        FinancialStats GetStats();
    }
}
