using System.ComponentModel.DataAnnotations;

namespace Hr_System.Models
{
    public class PublicHolidays
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Day { get; set; }
    }
}
