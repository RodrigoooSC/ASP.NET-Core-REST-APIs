using System.ComponentModel.DataAnnotations;

namespace UsuarioAPI.Data.Requests
{
    public class AtivaContaRequest // Classe de confirmação de cadastro
    {
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public string CodigoDeAtivacao { get; set; }
    }
}