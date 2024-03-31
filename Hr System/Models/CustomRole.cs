using Microsoft.AspNetCore.Identity;

namespace Hr_System.Models
{
    public class CustomRole : IdentityRole
    {
        // id
        //name
        public virtual ICollection<RolePermission> Permissions { get; set; }
    }
}
