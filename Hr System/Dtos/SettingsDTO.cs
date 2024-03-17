using Hr_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hr_System.Dtos
{
    public class SettingsDTO
    {
        public int Id { get; set; }
        public int OvertimeHour { get; set; }
        public int DiscountHour { get; set; }

        public List<WeekendDTO> WeekendDays { get; set; }

        //public string EmployeeName { get; set; }




    }

    
}
