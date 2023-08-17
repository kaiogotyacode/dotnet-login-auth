using System.ComponentModel.DataAnnotations;

namespace LoginAuth.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string? Password { get; set; }
}
    }
