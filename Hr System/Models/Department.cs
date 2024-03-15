using System.ComponentModel.DataAnnotations;

namespace Hr_System.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string DeptName { get; set;}
       
        // Navigation property to Employees
        public ICollection<Employee> Employees { get; set; }
    }
}
