using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsuarioAPI.Data
{
    // Definindo o contexto com o identity
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>  
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {            
        }
    }
}