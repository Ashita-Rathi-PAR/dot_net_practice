using ServiceRepositoryPattern.Models;
namespace ServiceRepositoryPattern.Services
{
    public interface ITicketService
    {
        List<Ticket> GetAllSold();
    }
}
