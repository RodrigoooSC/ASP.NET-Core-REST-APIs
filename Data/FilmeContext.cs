using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext // Classe de controle do contexto entre nossa aplicação e o banco de dados
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
        {            
        }

        public DbSet<Filme> Filmes {get; set;} // Propriedade que vai mapear de forma encapsulada os dados dos filmes.        
    }
}