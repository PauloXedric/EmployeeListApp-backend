using AutoMapper;
using EmployeeListApp.Entities;
using EmployeeListApp.Enums;
using EmployeeListApp.Models.EmployeeModels;
using EmployeeListApp.Repositories;

namespace EmployeeListApp.Services
{
    public interface IEmployeeService
    {
        Task<List<ReadEmployeeModel>> GetAllEmployeesAsync();
        Task<ReadEmployeeModel?> GetEmployeeByIdAsync(Guid id);
        Task<Result> AddEmployeeAsync(AddEmployeeModel model);
        Task<Result> UpdateEmployeeAsync(UpdateEmployeeModel model);
        Task<Result> DeleteEmployeeAsync(Guid id);
    }


    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        public async Task<List<ReadEmployeeModel>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<List<ReadEmployeeModel>>(employees);
        }

        public async Task<ReadEmployeeModel?> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return null;
            }

            return _mapper.Map<ReadEmployeeModel>(employee);
        }

        public async Task<Result> AddEmployeeAsync(AddEmployeeModel model)
        {
            var entity = _mapper.Map<EmployeeEntity>(model);
            var created = await _employeeRepository.CreateAsync(entity);

            return created ? Result.Success : Result.Failed;
        }

        public async Task<Result> UpdateEmployeeAsync(UpdateEmployeeModel model)
        {
            var entity = _mapper.Map<EmployeeEntity>(model);
            var success = await _employeeRepository.UpdateAsync(entity);

            return success ? Result.Success : Result.DoesNotExist;
        }

        public async Task<Result> DeleteEmployeeAsync(Guid id)
        {
            var success = await _employeeRepository.DeleteAsync(id);
            return success ? Result.Success : Result.DoesNotExist;
        }
    }
}
