using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        [Required(ErrorMessage = "O campo título é obrigatório")] // Campo requirido com tratamento de erro
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")] // Limita a digitação de caracteres
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600 minutos")] // Limita a quantidade de minutos no atributo
        public int Duracao { get; set; }
         public string ClassificacaoEtaria { get; set; }
        public DateTime HoraDaConsulta { get; set; }
        
        
    }
}