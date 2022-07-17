using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        [Required(ErrorMessage = "O campo título é obrigatório")] // Campo requirido com tratamento de erro
        public string Titulo { get; set; }        
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")] // Limita a digitação 
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600 minutos")] // Limita a quantidade de minutos no atributo
        public int Duracao { get; set; }
        public string Genero { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]        
        [StringLength(100, ErrorMessage = "O nome do diretor não pode exceder 100 caracterres")] // Limita a digitação de caracteres
        public string Diretor { get; set; }
        public int ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
        
        
        
        
    }
}