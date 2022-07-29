using System.Linq;
using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            // Personaliza o mapeamento da entidade gerente em um objeto anonimo para retornar os dados especificos na consulta.
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select
                (cinema => new {cinema.Id, cinema.Nome, cinema.Endereco, cinema.EnderecoId})));

            CreateMap<UpdateGerenteDto, Gerente>(); 
        }         
    }
}