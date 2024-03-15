using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hr_System.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan? LeaveTime { get; set; }
        // Navigation property to Employee
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
