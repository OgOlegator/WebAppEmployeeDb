using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppEmployeeDb.Data.DbContexts;
using WebAppEmployeeDb.Data.Models;

namespace WebAppEmployeeDb.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository()
        {
            _db = new ApplicationDbContext();
        }   

        public async Task<Employee> CreateUpdate(Employee employee)
        {
            if(employee.Id > 0)
            {
                var changeEmployee = _db.Employees.FirstOrDefault(change => change.Id == employee.Id);
                changeEmployee = employee;
            }
            else
            {
                _db.Employees.Add(employee);
            }

            await _db.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> Delete(int id)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(employee => employee.Id == id);

            if (employee == null)
                return false;

            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            var employees = await _db.Employees.ToListAsync();
                
            return employees;
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(employee => employee.Id == id);

            if (employee == null)
                throw new KeyNotFoundException();   // Todo Думаю лучше сделать свой exception

            return employee;
        }
    }
}
