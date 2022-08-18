using EmployeeApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration Configuration)
        {
            _logger = logger;
            _configuration = Configuration;
        }

        public IActionResult Index()
        {
            List<Employee> employeeList = new List<Employee>();
            string CS = _configuration.GetConnectionString("DBCS");
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var employee = new Employee();

                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Age = Convert.ToInt32(rdr["Age"]);
                    employee.Position = rdr["Position"].ToString();
                    employee.Office = rdr["Office"].ToString();
                    employee.HireDate = Convert.ToDateTime(rdr["HireDate"]);
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employeeList.Add(employee);
                }
            }
            return View(employeeList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}