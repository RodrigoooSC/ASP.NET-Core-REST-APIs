using System.ComponentModel.DataAnnotations;

namespace UsuarioAPI.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}