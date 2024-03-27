using System.ComponentModel.DataAnnotations;

namespace Hr_System.Models
{
    public class RegisterModel
    {
        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }
        [Required, StringLength(128)]
        public string Password { get; set; }

        [Required, StringLength(256)]
        public string Email { get; set; }

        public string roleName { get; set; }
    }
}
