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
        public int EnderecoId { get; set; } // Identifica de fato o seu endereco
        
    }
}