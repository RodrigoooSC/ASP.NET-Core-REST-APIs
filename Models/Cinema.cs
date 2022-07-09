using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo nome é obrigatório")]
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; } // O cinema possui um endereco
        public int EnderecoId { get; set; } // Identifica o seu endereco
        public virtual Gerente Gerente { get; set; } // O cinema possui um gerente
        public int GerenteId { get; set; } // Identifica o seu gerente  
    }
}