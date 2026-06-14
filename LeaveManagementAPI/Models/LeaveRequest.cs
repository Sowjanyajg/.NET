using System.ComponentModel.DataAnnotations;

namespace LeaveManagementAPI.Models
{
    public class LeaveRequest
    {
        public int LeaveRequestId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Reason { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        // Navigation property
        public Employee? Employee { get; set; }
    }
}