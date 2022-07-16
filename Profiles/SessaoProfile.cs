using System.Linq;
using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();            
            CreateMap<Sessao, ReadSessaoDto>()
            // Executa a subtração do horario da sessão em tempo de execução, para exibir o horario de inicio do filme          
            .ForMember(sessao => sessao.HorarioDeInicio, opts => opts.MapFrom(sessao => sessao.HorarioDeEncerramento.AddMinutes(sessao.Filme.Duracao * (-1))));
            CreateMap<UpdateSessaoDto, Sessao>(); 
        }         
    }
}