using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UsuarioAPI.Data
{
    // Definindo o contexto com o identity
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>  
    {
        // Configurando serviço para acessar as secrets
        private IConfiguration _configuration;

        public UserDbContext(DbContextOptions<UserDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            IdentityUser<int> admin = new IdentityUser<int>
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id= 99999  
            };

            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();

            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("adminInfo:password"));

            builder.Entity<IdentityUser<int>>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData
            (
                new IdentityRole<int>
                {
                    Id = 99999,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }
            );

            builder.Entity<IdentityRole<int>>().HasData
            (
                new IdentityRole<int>
                {
                    Id = 99998,
                    Name = "regular",
                    NormalizedName = "REGULAR"
                }
            );

            builder.Entity<IdentityUserRole<int>>().HasData
            (
                new IdentityUserRole<int>
                {
                    RoleId = 99999,
                    UserId = 99999
                    
                }
            );
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