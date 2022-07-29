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

        // protected override void OnModelCreating(ModelBuilder builder)
        // {  
        //     builder.Entity<IdentityUserLogin<int>>(entity => 
        //     {
        //         entity.Property(x => x.LoginProvider).HasMaxLength(110);
        //         entity.Property(x => x.ProviderKey).HasMaxLength(127);
        //     });

        //     builder.Entity<IdentityUserRole<int>>(entity => 
        //     {
        //         entity.Property(m => m.UserId).HasMaxLength(127);
        //         entity.Property(m => m.RoleId).HasMaxLength(127);
        //     });

        //     builder.Entity<IdentityUserToken<int>>(entity => 
        //     {
        //         entity.Property(m => m.UserId).HasMaxLength(110);
        //         entity.Property(m => m.LoginProvider).HasMaxLength(110);
        //         entity.Property(m => m.Name).HasMaxLength(110);
        //     });        
        // }
    }
}