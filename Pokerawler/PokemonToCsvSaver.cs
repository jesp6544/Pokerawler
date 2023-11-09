using Pokerawler.Models;

namespace Pokerawler;

public static class PokemonToCsvSaver
{
    public static void Persist(List<Pokemon> pokemons, string filename = "data")
    {
        foreach (var pokemon in pokemons)
        {
            Directory.CreateDirectory("data");
            File.AppendAllText($"data/{filename}.csv", 
                $"{pokemon.Number},{pokemon.Name}{Environment.NewLine}");
        }
    }
}