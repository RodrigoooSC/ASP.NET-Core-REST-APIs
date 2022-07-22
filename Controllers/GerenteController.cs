using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;
        public GerenteController(GerenteService gerenteService)
        {
             _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readDto = _gerenteService.AdicionaGerente(gerenteDto);
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readDto.Id }, readDto);        
        }

        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            List<ReadGerenteDto> readDto = _gerenteService.RecuperaGerentes();
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDto readDto = _gerenteService.RecuperaGerentesPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
        {
            Result resultado =_gerenteService.AtualizaGerente(id, gerenteDto);            
            if (resultado.IsFailed) return NotFound();           
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result resultado = _gerenteService.DeletaGerente(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        
    }
}