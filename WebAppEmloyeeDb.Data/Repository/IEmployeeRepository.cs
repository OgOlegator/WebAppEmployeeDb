using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppEmployeeDb.Data.Models;

namespace WebAppEmployeeDb.Data.Repository
{
    public interface IEmployeeRepository
    {

        Task<IEnumerable<Employee>> Get();

        Task<Employee> GetById(int id);

        Task<Employee> CreateUpdate(Employee employee);

        Task<bool> Delete(int id);

    }
}
