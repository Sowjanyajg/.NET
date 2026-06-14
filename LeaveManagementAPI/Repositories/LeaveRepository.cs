using LeaveManagementAPI.Data;
using LeaveManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementAPI.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly AppDbContext _context;

        public LeaveRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LeaveRequest>> GetAllAsync()
        {
            return await _context.LeaveRequests
                .Include(l => l.Employee)
                .ToListAsync();
        }

        public async Task<LeaveRequest?> GetByIdAsync(int id)
        {
            return await _context.LeaveRequests
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(l => l.LeaveRequestId == id);
        }

        public async Task<LeaveRequest> AddAsync(LeaveRequest leave)
        {
            _context.LeaveRequests.Add(leave);
            await _context.SaveChangesAsync();
            return leave;
        }

        public async Task<LeaveRequest?> UpdateStatusAsync(int id, string status)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null) return null;

            leave.Status = status;
            await _context.SaveChangesAsync();
            return leave;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null) return false;

            _context.LeaveRequests.Remove(leave);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}