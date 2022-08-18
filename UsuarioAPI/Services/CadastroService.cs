using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        private UserManager<CustomIdentityUser> _userManeger;
        private EmailService _emailService;        

        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManeger = userManager;
            _emailService = emailService;            
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto); // converte createDto em usuario
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario); // converte usuario para IdentityUser
            Task<IdentityResult> resultadoIdentity = _userManeger.CreateAsync(usuarioIdentity, createDto.Password);
            // Criando Role regular
            _userManeger.AddToRoleAsync(usuarioIdentity, "regular");           

             // Executa um tarefa assincrona para cadastrar o usuario
            if(resultadoIdentity.Result.Succeeded) 
            {
                var code = _userManeger.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(new [] { usuarioIdentity.Email}, "Link de Ativação", usuarioIdentity.Id, encodedCode); // Envia email de confirmação com os parametros
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
            return Result.Fail("Falha ao ativar conta do usuário!");
        }
    }
}