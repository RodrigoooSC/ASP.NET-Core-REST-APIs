using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioAPI.Data.Dtos;
using UsuarioAPI.Models;

namespace UsuarioAPI.Services
{
    public class CadastroService
    {        
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManeger;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManeger = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto); // converte createDto em usuario
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario); // converte usuario para IdentityUser
            Task<IdentityResult> resultadoIdentity = _userManeger.CreateAsync(usuarioIdentity, createDto.Password); // Executa um tarefa assincrona para cadastrar o usuario
            if(resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário!");
        }
        
    }
}