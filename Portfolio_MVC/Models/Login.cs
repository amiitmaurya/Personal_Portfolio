using System.ComponentModel.DataAnnotations;

namespace Portfolio_MVC.Models
{
    public class LoginSignupViewModel
    {
        public LoginViewModel Login { get; set; }
        public SignupViewModel Signup { get; set; }
    }
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class SignupViewModel
    {
        // Signup fields
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }
    }
}