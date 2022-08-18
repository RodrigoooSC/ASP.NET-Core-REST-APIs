using System;
using Microsoft.AspNetCore.Identity;

namespace UsuarioAPI.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}