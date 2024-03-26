using Hr_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hr_System.Dtos
{
    public class SettingsDTO
    {
        public int OvertimeHour { get; set; }
        public int DiscountHour { get; set; }
        public string Weekend1 { get; set; }
        public string Weekend2 { get; set; }


    }

    
}
