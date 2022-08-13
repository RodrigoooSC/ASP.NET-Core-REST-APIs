using System.Collections.Generic;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")] // Define a rota da API neste caso a rota principal sera o nome da controller Filme
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        // Injeta as dependêcias no controller
        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost] // Adiciona um filme
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = _filmeService.AdicionaFilme(filmeDto);
            // retorna o status code 201 (Created) e a localização de onde o recurso pode ser acessado no nosso sistema
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet] // Recupera todos os filmes por classificacao etaria
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null) // Classificacao etari pode ser nula
        {
            List<ReadFilmeDto> readDto =  _filmeService.RecuperaFilmes(classificacaoEtaria);
            if(readDto != null) return Ok(readDto);            
            return NotFound();           
        }

        [HttpGet("{id}")] // Recupera um filme por id
        public IActionResult RecuperaFilmePorId(int id) // recebe o parametro id do verbo HttpGet("{id}")
        {
            ReadFilmeDto readDto = _filmeService.RecuperaFilmePorId(id); 
            if(readDto != null) return Ok(readDto);             
            return NotFound(); // caso não tenha nenhum dado na pesquisa, retorna o status code 404
        }

        [HttpPut("{id}")] // Atualiza um filme por id
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeAtualizarDto)
        {
           Result resultado =_filmeService.AtualizaFilme(id, filmeAtualizarDto);            
            if (resultado.IsFailed) return NotFound();           
            return NoContent();
        }

        [HttpDelete("{id}")] // Delete todos os filmes
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = _filmeService.DeletaFilme(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}