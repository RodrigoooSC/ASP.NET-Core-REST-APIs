using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FilmesAPI.Authorization
{
    
    public class IdadeMinimaHandler : AuthorizationHandler<IdadeMinimaRequirement>     
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinimaRequirement requirement)
        {
            // Executa a logica do calculo de idade de um usuario
            if(!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            return Task.CompletedTask;
            
            // Pega do context a data de nascimento e converte em datetime
            DateTime dataNascimento = Convert.ToDateTime(context.User.FindFirst(c => 
            c.Type ==ClaimTypes.DateOfBirth
            ).Value);
            
            int idadeObtida = DateTime.Today.Year - dataNascimento.Year;

            if(dataNascimento > DateTime.Today.AddYears(-idadeObtida))
            idadeObtida--;

            if(idadeObtida >= requirement.IdadeMinima) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}