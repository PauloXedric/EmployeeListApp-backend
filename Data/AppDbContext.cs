using EmployeeListApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmployeeEntity> Employee { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
