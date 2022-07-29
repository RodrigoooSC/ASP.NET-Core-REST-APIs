using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateSessaoDto
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; } 
        public DateTime HorarioDeEncerramento { get; set; }
    }
}