using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class FilmeService // Classe responsável por isolar a lógica da aplicação permitindo uma refatoração do código.
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            // Converte o filmedto em filme utilizando o mapper
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            //Se classificacao etaria for nula retorna todos os filmes
            if(classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                // Faz um consulta por classificacao etaria
                 filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }            
            if(filmes != null)
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return readDto;
            }

            return null;
        }

        public ReadFilmeDto RecuperaFilmePorId(int id)
        {
            // retorna o primeiro resultado da busca
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                // Cria um objeto para retornar os dados e faz o mapeamento usando o mapper
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                // caso a consulta não seja nula, retorno o status code 200 juntamente com o filme
                return filmeDto;
            }

            return null;
        }

        public Result AtualizaFilme(int id, UpdateFilmeDto filmeAtualizarDto)
        {            
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado!"); // Pacote FluentResults para retorno de resultados
            }           

            _mapper.Map(filmeAtualizarDto, filme); // Converte dois objetos relacionados entre sí
            _context.SaveChanges();

            return Result.Ok();
                             
        }

        internal Result DeletaFilme(int id)
        {
           Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) // Verifica se o filme existe
            {
                return Result.Fail("Filme não encontrado!");
            }
            _context.Remove(filme); // remove filme
            _context.SaveChanges(); // Salva as alterações

            return Result.Ok();
        }
    }
}