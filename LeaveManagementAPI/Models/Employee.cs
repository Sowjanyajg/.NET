
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

        // Navigation property
        public List<LeaveRequest> LeaveRequests { get; set; } = new();
    }
}