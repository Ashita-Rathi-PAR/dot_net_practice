using CompanyApp.Models;

namespace CompanyApp.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);
        void Save();
        bool EmployeeExists(int id);
    }
}
