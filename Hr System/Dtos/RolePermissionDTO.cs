using Hr_System.Models;

namespace Hr_System.Dtos
{
    public class RolePermissionDTO
    {
        public string RoleId { get; set; }
        public string Name { get; set; }

        public List<permissionsDTO> permissions { get; set; }

       
    }
}
