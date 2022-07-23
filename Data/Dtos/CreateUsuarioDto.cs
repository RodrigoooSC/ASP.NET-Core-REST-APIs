using System.ComponentModel.DataAnnotations;

namespace UsuarioAPI.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)] // Indica que o campo e uma senha
        public string Password { get; set; }
        [Required]
        [Compare("Password")] // Faz uma comparação enter os campos senha
        public string RePassword { get; set; }
        
    }
}