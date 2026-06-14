using LeaveManagementAPI.Models;

namespace LeaveManagementAPI.Services
{
    public interface ILeaveService
    {
        Task<List<LeaveRequest>> GetAllLeaves();
        Task<LeaveRequest?>      GetLeaveById(int id);
        Task<LeaveRequest>       ApplyLeave(LeaveRequest leave);
        Task<LeaveRequest?>      ApproveLeave(int id);
        Task<LeaveRequest?>      RejectLeave(int id);
        Task<bool>               DeleteLeave(int id);
    }
}