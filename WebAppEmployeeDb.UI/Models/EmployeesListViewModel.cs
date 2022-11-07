using WebAppEmployeeDb.Data.Models;

namespace WebAppEmployeeDb.UI.Models
{
    public class EmployeesListViewModel
    {

        public IEnumerable<Employee>? Employees { get; set; }

        //public string? SearchName { get; set; }

        //public string? CurrentJobTitle { get; set; }

        //public string? CurrentSubdivision { get; set; }

    }
}
