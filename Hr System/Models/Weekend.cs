using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hr_System.Models
{
    public class Weekend
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("GeneralSettings")]
        public int GeneralSettingsId { get; set; }

        public GeneralSettings GeneralSettings { get; set; }
    }
}
