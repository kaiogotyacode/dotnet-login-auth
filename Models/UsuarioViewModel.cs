using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAuth.Models;

public class UsuarioViewModel 
{
    [Key]
    public int UsuarioId { get; set; }
 
    [StringLength(100)]
    public string? Username { get; set; }
    [StringLength(100), EmailAddress]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? Password { get; set; }

    [NotMapped]
    public string? ConfirmPassword{ get; set; }
}

