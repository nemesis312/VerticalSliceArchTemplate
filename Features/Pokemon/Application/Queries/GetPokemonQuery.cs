using System.Data;
using MediatR;
using VerticalSliceArch.Common.Helpers;
using VerticalSliceArch.Features.Pokemon.Domain.DTOs;
using VerticalSliceArch.Features.Pokemon.Infrastructure.Services;

namespace VerticalSliceArch.Features.Pokemon.Application.Queries;

public class GetPokemonQuery:IRequest<PokemonDto>
{
    public int PokemonId { get; set; }
    
    public record GetPokemonQueryHandler:IRequestHandler<GetPokemonQuery, PokemonDto>
    {
        private readonly IPokemonService _pokemonService;    
        public GetPokemonQueryHandler(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        
        public async Task<PokemonDto> Handle(GetPokemonQuery request, CancellationToken cancellationToken)
        {
            var pokemon = await _pokemonService.GetPokemon(request.PokemonId);
            if(pokemon is null)
                throw new PokemonNotFoundException($"Pokemon with id {request.PokemonId} not found");    
            return pokemon;
        }
    }
}