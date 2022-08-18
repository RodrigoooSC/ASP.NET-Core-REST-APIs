using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioAPI.Data.Dtos;
using UsuarioAPI.Models;

namespace UsuarioAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>(); // Faz o mapeamento de CreateUsuarioDto para Usuario.
            CreateMap<Usuario, IdentityUser<int>>();
            CreateMap<Usuario, CustomIdentityUser>();

        }
    }
}