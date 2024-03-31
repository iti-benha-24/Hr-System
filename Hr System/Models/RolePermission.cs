using Newtonsoft.Json;

namespace Hr_System.Models
{
    public class RolePermission
    {
        public int Id { get; set; }
        public string RoleId { get; set; }

        [JsonIgnore]
        public CustomRole? Role { get; set; }

        public string Section { get; set; }
        public bool CanRead { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}
