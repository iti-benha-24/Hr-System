using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Hr_System.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required , MaxLength(255)]
        public string FullName { get; set; }
    }
}
