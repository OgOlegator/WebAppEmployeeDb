

using Microsoft.EntityFrameworkCore;
using WebAppEmployeeDb.Data.Models;

namespace WebAppEmployeeDb.Data.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(SD.ConnectionString);

    }
}
