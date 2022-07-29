using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateGerenteDto
    {
        [Required(ErrorMessage ="O campo nome é obrigatório")]
        public string Nome { get; set; }
    }
}