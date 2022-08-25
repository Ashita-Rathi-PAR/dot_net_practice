using CompanyApp.Models;

namespace CompanyApp.Service
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);
        void Save();
        bool EmployeeExists(int id);
    }
}
