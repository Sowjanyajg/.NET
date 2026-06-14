using LeaveManagementAPI.Models;
using LeaveManagementAPI.Repositories;

namespace LeaveManagementAPI.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _repository;

        public LeaveService(ILeaveRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LeaveRequest>> GetAllLeaves()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<LeaveRequest?> GetLeaveById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<LeaveRequest> ApplyLeave(LeaveRequest leave)
        {
            leave.Status = "Pending";
            return await _repository.AddAsync(leave);
        }

        public async Task<LeaveRequest?> ApproveLeave(int id)
        {
            return await _repository.UpdateStatusAsync(id, "Approved");
        }

        public async Task<LeaveRequest?> RejectLeave(int id)
        {
            return await _repository.UpdateStatusAsync(id, "Rejected");
        }

        public async Task<bool> DeleteLeave(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}