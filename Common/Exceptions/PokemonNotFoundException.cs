namespace VerticalSliceArch.Common.Helpers;

public class PokemonNotFoundException: Exception
{
    public PokemonNotFoundException()
    {
        
    }
    public PokemonNotFoundException(string message): base(message)
    {
        
    }

    public PokemonNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }


}