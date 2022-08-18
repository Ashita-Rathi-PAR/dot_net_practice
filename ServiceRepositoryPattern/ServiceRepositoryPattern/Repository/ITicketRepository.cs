using ServiceRepositoryPattern.Models;

namespace ServiceRepositoryPattern.Repository
{
    public interface ITicketRepository
    {
        List<Ticket> GetAllSold();
    }
}
