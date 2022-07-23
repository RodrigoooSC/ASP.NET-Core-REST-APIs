using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Data.Dtos;

namespace UsuarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            // Chamar o service para cadastrar um usuario
            return Ok();
        }
        
    }
}