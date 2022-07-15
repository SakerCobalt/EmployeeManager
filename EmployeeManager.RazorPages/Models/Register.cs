using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.RazorPages.Models
{
    public class Register
    {
        [Required, Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, Display(Name="Confirm Password"), Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Display(Name="Full Name")]
        public string FullName { get; set; }

        [Required, Display(Name="Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
