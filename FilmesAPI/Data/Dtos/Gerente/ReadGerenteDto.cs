using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class ReadGerenteDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo nome é obrigatório")]
        public string Nome { get; set; }
        public object Cinemas { get; set; }
    }
}