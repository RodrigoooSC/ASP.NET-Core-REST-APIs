using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")] // Define a rota da API neste caso a rota principal sera o nome da controller Filme
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>(); // Cria uma lista de filmes paar ser manipulada em tempo de execução
        private static int id = 1; // Cria o id dos filmes


        [HttpPost] // Adiciona um filme
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++; // Adiciona um id ao filme
            filmes.Add(filme); // Adiciona um filme na lista
            // retorna o status code 201 (Created) e a localização de onde o recurso pode ser acessado no nosso sistema
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme); 
        }

        [HttpGet] // Recupera todos os filmes
        public IActionResult RecuperaFilmes()
        {
            return Ok(filmes); // retorna o status code 200 de success juntamente com a lista de filmes
        }

        [HttpGet("{id}")] // Recupera um filme por id
        public IActionResult RecuperaFilmePorId(int id) // recebe o parametro id do verbo HttpGet("{id}")
        {
            // retorna o primeiro resultado da busca
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id); 
            if (filme != null) 
            {
                // caso a consulta não seja nula, retorno o status code 200 juntamente com o filme
                return Ok(filme);
            }
            return NotFound(); // caso não tenha nenhum dado na pesquisa, retorna o status code 404
        }

    }
}