using LoginAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAuth.Context;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }


}

