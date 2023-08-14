using System.ComponentModel.DataAnnotations;

namespace LoginAuth.ViewModels;

public class UsuarioViewModel
{
    [Required(ErrorMessage = "Username is required!")]
    [Display(Name = "User")]
    public string? Username { get; set; }
    [Required(ErrorMessage = "Password is required!")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    public string? ReturnUrl { get; set; }
}

