using Newtonsoft.Json;

namespace VerticalSliceArch.Features.Pokemon.Domain.DTOs;

public class PokemonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public PokemonSprites Sprites { get; set; }
}

public class PokemonSprites
{
    public PokemonOfficialArtwork Other { get; set; }
}
public class PokemonOfficialArtwork
{
    [JsonProperty("official-artwork")]
    public PokemonOfficialArtworkProps officialartwork { get; set; }
}
public class PokemonOfficialArtworkProps
{
    public string front_default { get; set; }
    public string front_shiny { get; set; }
}