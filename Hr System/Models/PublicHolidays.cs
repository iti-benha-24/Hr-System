using System.ComponentModel.DataAnnotations;

namespace Hr_System.Models
{
    public class PublicHolidays
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Day { get; set; }
    }
}
