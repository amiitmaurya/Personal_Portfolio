using System.ComponentModel.DataAnnotations;

namespace Portfolio_MVC.Models
{
    public class ChangePasswordViewModel
    {
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
