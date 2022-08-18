using DapperApplication.Models;
using System.Collections;
namespace DapperApplication.Dapper
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Find(int id);
        User Add(User user);
        User Update(User user);
        void Remove(int id);
        User GetUserInformatiom(int id);
    }
}
