using CompanyApp.Models;
using CompanyApp.Repository;

namespace CompanyApp.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public List<Employee> GetAllEmployees() => (List<Employee>)_employeeRepo.GetAllEmployees();

        public Employee GetEmployeeById(int id) => _employeeRepo.GetEmployeeById(id);
        public void AddEmployee(Employee employee) => _employeeRepo.AddEmployee(employee);
        public void UpdateEmployee(Employee employee) => _employeeRepo.UpdateEmployee(employee);
        public void DeleteEmployee(int id) => _employeeRepo.DeleteEmployee(id);
        public void Save() => _employeeRepo.Save();
        public bool EmployeeExists(int id) => _employeeRepo.EmployeeExists(id);

    }   
}
