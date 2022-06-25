using System.Collections.Generic;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FilmeController : ControllerBase
    {
        List<Filme> filmes = new List<Filme>();


        [HttpPost]
        public void AdicionaFilme([FromBody]Filme filme)
        {
            filmes.Add(filme);
        }
        
    }
}