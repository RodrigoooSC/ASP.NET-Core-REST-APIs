using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")] // Define a rota da API neste caso a rota principal sera o nome da controller Filme
    public class FilmeController : ControllerBase
    {

        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }


        [HttpPost] // Adiciona um filme
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            // retorna o status code 201 (Created) e a localização de onde o recurso pode ser acessado no nosso sistema
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme); 
        }

        [HttpGet] // Recupera todos os filmes
        public IActionResult RecuperaFilmes()
        {
            return Ok(_context.Filmes); // retorna o status code 200 de success juntamente com a lista de filmes
        }

        [HttpGet("{id}")] // Recupera um filme por id
        public IActionResult RecuperaFilmePorId(int id) // recebe o parametro id do verbo HttpGet("{id}")
        {
            // retorna o primeiro resultado da busca
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); 
            if (filme != null) 
            {
                // caso a consulta não seja nula, retorno o status code 200 juntamente com o filme
                return Ok(filme);
            }
            return NotFound(); // caso não tenha nenhum dado na pesquisa, retorna o status code 404
        }

    }
}