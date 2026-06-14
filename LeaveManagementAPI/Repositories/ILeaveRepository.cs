using LeaveManagementAPI.Models;

namespace LeaveManagementAPI.Repositories
{
    public interface ILeaveRepository
    {
        Task<List<LeaveRequest>> GetAllAsync();
        Task<LeaveRequest?>      GetByIdAsync(int id);
        Task<LeaveRequest>       AddAsync(LeaveRequest leave);
        Task<LeaveRequest?>      UpdateStatusAsync(int id, string status);
        Task<bool>               DeleteAsync(int id);
    }
}