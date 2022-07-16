using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos
{
    public class ReadSessaoDto
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}