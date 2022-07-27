using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioAPI.Data.Dtos;
using UsuarioAPI.Data.Requests;
using UsuarioAPI.Models;

namespace UsuarioAPI.Services
{
    public class CadastroService
    {        
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManeger;
        private EmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManeger = userManager;
            _emailService = emailService;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto); // converte createDto em usuario
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario); // converte usuario para IdentityUser
            Task<IdentityResult> resultadoIdentity = _userManeger.CreateAsync(usuarioIdentity, createDto.Password); // Executa um tarefa assincrona para cadastrar o usuario
            if(resultadoIdentity.Result.Succeeded) 
            {
                var code = _userManeger.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                _emailService.EnviarEmail(new []{ usuarioIdentity.Email}, "Link de Ativação", usuarioIdentity.Id, code); // Envia email de confirmação com os parametros
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário!");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var IdentityUser = _userManeger
            .Users
            .FirstOrDefault(usuario => usuario.Id == request.UsuarioId); // Recupera um usuario

            var IdentityResult = _userManeger.ConfirmEmailAsync(IdentityUser, request.CodigoDeAtivacao).Result; // faz a confirmação no db
            if(IdentityResult.Succeeded) 
            {                
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativaqr conta do usuário!");
        }
    }
}