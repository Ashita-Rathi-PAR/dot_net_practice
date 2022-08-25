using CompanyApp.Data;
using CompanyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _db;
        public EmployeeRepository()
        {
            _db = new EmployeeContext();
        }
        public EmployeeRepository(EmployeeContext db)
        {
            _db = db;
        }

        public void AddEmployee(Employee employee)
        {
            _db.Employee.Add(employee);
            Save();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employee.Find(id);
            if (employee != null) 
                _db.Employee.Remove(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _db.Employee.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _db.Employee.Find(id);
        }

        public void Save()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            _db.Entry(employee).State = EntityState.Modified;
        }

        public bool EmployeeExists(int id)
        {
            return (_db.Employee?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
