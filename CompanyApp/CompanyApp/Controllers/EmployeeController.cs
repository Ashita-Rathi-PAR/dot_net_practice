using Microsoft.AspNetCore.Mvc;
using CompanyApp.Service;
using CompanyApp.Models;
using CompanyApp.Exception;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Running at: {time}", DateTimeOffset.UtcNow);
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            _logger.LogWarning("Details of Employee:{id}",id);
            var employee = _employeeService.GetEmployeeById(id);
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            _logger.LogInformation("Employee Created:{name}",employee.Name);
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(employee);
                _employeeService.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            _logger.LogInformation("Employee Information Edited:{name}", employee.Name);
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(employee);
                _employeeService.Save();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [EmployeeNotFoundException]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Employee Delted:{id}", id);
            if (!_employeeService.EmployeeExists(id))
            {
                return View("EmployeeNotFoundError");
            }
            
            var employee = _employeeService.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [EmployeeNotFoundException]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_employeeService.EmployeeExists(id))
            {
                return View("EmployeeNotFoundError");
            }
            _employeeService.DeleteEmployee(id);
            _employeeService.Save();
            return RedirectToAction("Index");
        }


        public IActionResult ErrorIndex()
        {
            int i = 10;
            i = i / 0;
            return View();
        }
    }

}


// Unit Test Cases:
// Employee not found while finding updating deleteing
// Zero employees is list in in GelAllEmployees()
// 
   