using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de logradouro é obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo de bairro é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo de número é obrigatório")]
        public int Numero { get; set; }
        [JsonIgnore]// Ao consultar um endereco ele não retorna esta propriedade, resolvendo o problema de ciclo infinito de consulta.
        public virtual Cinema Cinema { get; set; } // Conceito de sobrescrita de metodos
        
        
    }
}