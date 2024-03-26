using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hr_System.Models
{
    public class GeneralSettings
    {
        [Key]
        public int Id { get; set; }
        public int OvertimeHour { get; set; }
        public int DiscountHour { get; set; }
       public string Weekend1 { get; set; }
       public string Weekend2 { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
