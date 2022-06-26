using System;
using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
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
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            // Converte o filmedto em filme
            Filme filme = new Filme 
            {
                Titulo = filmeDto.Titulo,
                Diretor = filmeDto.Diretor,
                Genero = filmeDto.Genero,
                Duracao = filmeDto.Duracao
            };

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            // retorna o status code 201 (Created) e a localização de onde o recurso pode ser acessado no nosso sistema
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme); 
        }

        [HttpGet] // Recupera todos os filmes
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes; // retorna a lista de filmes
        }

        [HttpGet("{id}")] // Recupera um filme por id
        public IActionResult RecuperaFilmePorId(int id) // recebe o parametro id do verbo HttpGet("{id}")
        {
            // retorna o primeiro resultado da busca
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); 
            if (filme != null) 
            {
                // Cria um objeto para retornar os dados de sua maneira
                ReadFilmeDto filmeDto = new ReadFilmeDto
                {
                    Titulo = filme.Titulo,
                    Diretor  =filme.Diretor,
                    Genero = filme.Genero,
                    Duracao = filme.Duracao,
                    HoraDaConsulta = DateTime.Now

                };
                // caso a consulta não seja nula, retorno o status code 200 juntamente com o filme
                return Ok(filmeDto);
            }
            return NotFound(); // caso não tenha nenhum dado na pesquisa, retorna o status code 404
        }

        [HttpPut("{id}")] // Atualiza um filme por id
        public IActionResult AtualizaFilme(int id,[FromBody] UpdateFilmeDto filmeAtualizarDto) 
        {
            
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); 
            if (filme == null) // Verifica se o filme existe
            {                
                return NotFound();
            }
            filme.Titulo = filmeAtualizarDto.Titulo;
            filme.Diretor = filmeAtualizarDto.Diretor;
            filme.Genero = filmeAtualizarDto.Genero;
            filme.Duracao = filmeAtualizarDto.Duracao;
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")] // Delete todos os filmes
        public IActionResult DeletaFilme(int id)
        {
             Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); 
            if (filme == null) // Verifica se o filme existe
            {                
                return NotFound();
            }
            _context.Remove(filme); // remove filme
            _context.SaveChanges(); // Salva as alterações
            return NoContent();
        }

    }
}