using Newtonsoft.Json;
using VerticalSliceArch.Features.Pokemon.Domain.DTOs;

namespace VerticalSliceArch.Features.Pokemon.Infrastructure.Services;

public interface IPokemonService
{
    Task<PokemonDto?> GetPokemon(int pokemonId);
}

public class PokemonService : IPokemonService
{
    public async Task<PokemonDto?> GetPokemon(int pokemonId)
    {
        var client = new HttpClient();
        var response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonId}/");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var pokemonDto = JsonConvert.DeserializeObject<PokemonDto>(content);
            return pokemonDto;
        }

        return null;
    }
}