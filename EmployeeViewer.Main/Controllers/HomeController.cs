using EmployeeViewer.Main.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeViewer.Main.Controllers
{
    [Route("{controller}/{action}")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet]
        [Route("")]
        [Route("/")]
        public IActionResult Index()
        {
            // Get List of Employees from Database here. Currently Hardcoded for Demo.

            var employees = new List<Employee>()
            {
                new Employee() { EmployeeID = 1, FirstName = "FName 1", LastName = "LName 1", Age = 25, Salary = 10000 },
                new Employee() { EmployeeID = 2, FirstName = "FName 2", LastName = "LName 2", Age = 26, Salary = 10000 },
                new Employee() { EmployeeID = 3, FirstName = "FName 3", LastName = "LName 3", Age = 27, Salary = 10000 },
                new Employee() { EmployeeID = 4, FirstName = "FName 4", LastName = "LName 4", Age = 28, Salary = 10000 },
                new Employee() { EmployeeID = 5, FirstName = "FName 5", LastName = "LName 5", Age = 29, Salary = 10000 },
            };
            return View(employees);
        }

        [HttpGet]
        public IActionResult AddOrEdit(int? employeeId)
        {
            ViewBag.PageName = employeeId == null ? "Create Employee" : "Edit Employee";
            ViewBag.IsEdit = employeeId == null ? false : true;

            if (employeeId == null)
            {
                return View();
            }
            else
            {
                // Get Details of an Employee from Database or External Service. Hardcoded for Demo purpose.

                var employee = new Employee()
                {
                    EmployeeID = 12,
                    FirstName = "FName 12",
                    LastName = "LName 12",
                    Age = 30,
                    Salary = 15000
                };

                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int employeeId, Employee employeeData)
        {
            bool IsEmployeeExist = false;
            bool validationResult = true;

            // Get Details of an Employee from Database or External Service. Hardcoded for Demo purpose.

            var employee = new Employee()
            {
                EmployeeID = 12,
                FirstName = "FName 12",
                LastName = "LName 12",
                Age = 30,
                Salary = 15000
            };

            if (employee != null)
            {
                IsEmployeeExist = true;
            }
            else
            {
                employee = new Employee();
            }

            if (validationResult)
            {
               // Call to External Service or DB to Add or Edit employee and return to Default Collection view

                return RedirectToAction(nameof(Index));
            }

            // Display Validaiton Errors Add/Edit Screen.
            return View(employeeData);
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
