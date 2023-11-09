using Pokerawler.Models;

namespace Pokerawler;

public static class PokemonToCsvSaver
{
    public static void Persist(List<Pokemon> pokemons)
    {
        foreach (var pokemon in pokemons)
        {
            File.AppendAllText("data.csv", 
                $"{pokemon.Number},{pokemon.Name}{Environment.NewLine}");
        }
    }
}