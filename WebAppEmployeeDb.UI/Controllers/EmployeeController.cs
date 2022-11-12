using Microsoft.AspNetCore.Mvc;
using WebAppEmployeeDb.Data.Models;
using WebAppEmployeeDb.Data.Repository;
using WebAppEmployeeDb.UI.Models;

namespace WebAppEmployeeDb.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> EmployeeIndex(string searchName, string searchJobTitle, string searchSubdivision)
        {
            var listEmployees = await _repository.Get();

            var employeesForView = new EmployeesListViewModel();

            employeesForView.Employees = listEmployees
                .Where(employee => searchName == null || employee.Name.Contains(searchName))
                .Where(employee => searchJobTitle == null || employee.JobTitle == searchJobTitle)
                .Where(employee => searchSubdivision == null || employee.Subdivision == searchSubdivision);

            return View(employeesForView);
        }

        public async Task<IActionResult> EmployeeCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployeeCreate(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateUpdate(model);
            }

            return View(new Employee());
        }

        public async Task<IActionResult> EmployeeDelete(int id)
        {
            try
            {
                var employee = await _repository.GetById(id);

                if (employee == null) 
                    return NotFound();

                return View(employee);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeDelete(Employee model)
        {
            var result = await _repository.Delete(model.Id);

            if (!result)
                View(model);

            return RedirectToAction(nameof(EmployeeIndex));
        }

        public async Task<IActionResult> EmployeeEdit(int id)
        {
            var employee = await _repository.GetById(id);

            if (employee == null)
                return NotFound();
            
            return View(employee);    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployeeEdit(Employee model)
        {
            if (ModelState.IsValid)
            {
                var employee = await _repository.CreateUpdate(model);

                if (employee != null)
                    return RedirectToAction(nameof(EmployeeIndex));
            }

            return View(model);
        }

        public async Task<IActionResult> EmployeeDetails(int id)
        {
            var employee = await _repository.GetById(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }
    }
}
