using LeaveManagementAPI.Models;
using LeaveManagementAPI.Repositories;

namespace LeaveManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            return await _repository.AddAsync(employee);
        }

        public async Task<Employee?> UpdateEmployee(int id, Employee employee)
        {
            return await _repository.UpdateAsync(id, employee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}