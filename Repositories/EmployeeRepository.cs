using EmployeeListApp.Data;
using EmployeeListApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> CreateAsync(EmployeeEntity employee);
        Task<EmployeeEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<EmployeeEntity>> GetAllAsync();
        Task<bool> UpdateAsync(EmployeeEntity employee);
        Task<bool> DeleteAsync(Guid id);
    }


    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> CreateAsync(EmployeeEntity employee)
        {
            _dbContext.Employee.Add(employee);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<EmployeeEntity?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Employee.FindAsync(id);
        }


        // Used Stored Procedure for Bonus Points
        public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
        {
            return await _dbContext.Employee
                .FromSqlRaw("EXEC sp_GetAllEmployees")
                .ToListAsync();
        }


        public async Task<bool> UpdateAsync(EmployeeEntity employee)
        {
            var exists = await _dbContext.Employee.AnyAsync(e => e.Id == employee.Id);

            if (!exists)
            {
                return false;
            }

            _dbContext.Employee.Update(employee);

            var result  =  await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var employee = await _dbContext.Employee.FindAsync(id);

            if (employee == null)
            {
                return false;
            } 

            _dbContext.Employee.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
