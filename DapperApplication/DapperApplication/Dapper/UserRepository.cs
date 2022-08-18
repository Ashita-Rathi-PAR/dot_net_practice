using Dapper;
using DapperApplication.Models;
using System.Data;
using System.Data.SqlClient;

namespace DapperApplication.Dapper
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration? _configuration;

        public UserRepository(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public List<User> GetAll()
        {
            SqlConnection _db = new SqlConnection(_configuration.GetConnectionString("DapperApplicationContext"));
            return _db.Query<User>("SELECT * FROM Users").ToList();
        }

        public User Find(int id)
        {
            SqlConnection _db = new SqlConnection(_configuration.GetConnectionString("DapperApplicationContext"));
#pragma warning disable CS8603 // Possible null reference return.
            return _db.Query<User>("SELECT * FROM Users WHERE UserID = @UserID", new { id }).SingleOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public User Add(User user)
        {
            SqlConnection _db = new SqlConnection(_configuration.GetConnectionString("DapperApplicationContext"));

            var sqlQuery = "INSERT INTO Users (FirstName, LastName, Email) VALUES(@FirstName, @LastName, @Email); " + 
            "SELECT CAST(SCOPE_IDENTITY() as int)";
            var userId = _db.Query<int>(sqlQuery, user).Single();
            user.UserID = userId;
            return user;
        }

        public User Update(User user)
        {
            SqlConnection _db = new SqlConnection(_configuration.GetConnectionString("DapperApplicationContext"));
            var sqlQuery =
                "UPDATE Users " +
                "SET FirstName = @FirstName, " +
                "    LastName  = @LastName, " +
                "    Email     = @Email " +
                "WHERE UserID = @UserID";
            _db.Execute(sqlQuery, user);
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserInformatiom(int id)
        {
            SqlConnection _db = new SqlConnection(_configuration.GetConnectionString("DapperApplicationContext"));
            using (var multipleResults = _db.QueryMultiple("GetUserByID",
            new { Id = id }, commandType: CommandType.StoredProcedure))
            {
                var user = multipleResults.Read<User>().SingleOrDefault();

                var addresses = multipleResults.Read<Address>().ToList();
                if (user != null && addresses != null)
                {
                    user.Address.AddRange(addresses);
                }

#pragma warning disable CS8603 // Possible null reference return.
                return user;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
    }
}
