using Pokerawler.Models;

namespace Pokerawler;

public static class PokemonToCsvSaver
{
    private const string EmptyString = "";
    
    public static void Persist(List<Pokemon> pokemons, string filename = "data")
    {
        Directory.CreateDirectory("data");
        MakeHeader(filename, pokemons.Count);
        foreach (var pokemon in pokemons)
        {
            var rowNumber = ConvertPokemonNumberToRowNumber(pokemon.Number);
            File.AppendAllText($"data/{filename}.csv", 
                MakeRow(pokemon.Number, pokemon.Name, colF: $"=SUM(C{rowNumber}:E{rowNumber})",
                    colG: $"=M{rowNumber}",
                    colH: $"=SUM(I{rowNumber}:K{rowNumber})",
                    colM: $"=IF($N{rowNumber}>0; IF($N{rowNumber} >1; P$2; P$1);\"\")",
                    colN: $"=SUM(O{rowNumber}:P{rowNumber})",
                    colO: $"=IF(OR(AND($F{rowNumber}>1; $H{rowNumber}=0); AND($H{rowNumber}>1; $F{rowNumber}=0)); 1; 0)",
                    colP: $"=IF(OR(AND($D{rowNumber}>1; $J{rowNumber}=0); AND($J{rowNumber}>1; $D{rowNumber}=0)); 2; 0)"
                    ));
        }
        
        MakeFooter(pokemons.Count);
    }

    private static void MakeHeader(string filename = "data", int totalNumberOfPokemons = 0)
    {
        File.AppendAllText($"data/{filename}.csv", 
            MakeRow(colC: "Søren", colD: "Mangler:", 
                colE:$"=COUNTIF(F4:F{ConvertPokemonNumberToRowNumber(totalNumberOfPokemons)}; \"=0\")&\" (\"&COUNTIF(F4:F{ConvertPokemonNumberToRowNumber(totalNumberOfPokemons)}; \"=0\")&\")\"", 
                colG: totalNumberOfPokemons.ToString(), colH: "Post", colJ: "Mangler:", 
                colK: $"=COUNTIF(H4:H{ConvertPokemonNumberToRowNumber(totalNumberOfPokemons)}; \"=0\")&\" (\"&COUNTIF(H4:H{ConvertPokemonNumberToRowNumber(totalNumberOfPokemons)}; \"=0\")&\")\"",
                colP: "BYT"));
        File.AppendAllText($"data/{filename}.csv", 
            MakeRow(colD: "Antal secrets:", colJ: "Antal secrets:", colP: "BYT REVERSE"));
        File.AppendAllText($"data/{filename}.csv", 
            MakeRow(colC: "Normal:", colD: "Reverse", colE: "Holo/ex osv", colI: "Normal:", colJ: "Reverse", colK: "Holo/ex osv"));
    }

    private static void MakeFooter(int totalNumberOfPokemons = 0, string filename = "data")
    {
        File.AppendAllText($"data/{filename}.csv", 
            MakeRow(colF: $"=sum(F$4:F{ConvertPokemonNumberToRowNumber(totalNumberOfPokemons)})",
                colH: $"=sum(H$4:H{ConvertPokemonNumberToRowNumber(totalNumberOfPokemons)})"));
    }
    
    private static int ConvertPokemonNumberToRowNumber(string pokemonNumber)
    {
        return int.Parse(pokemonNumber[1..]) + 3;
    }
    
    private static int ConvertPokemonNumberToRowNumber(int pokemonNumber)
    {
        return pokemonNumber + 3;
    }

    private static string MakeRow(string colA = EmptyString, string colB = EmptyString, string colC = EmptyString, string colD = EmptyString, string colE = EmptyString, string colF = EmptyString,
        string colG = EmptyString, string colH = EmptyString, string colI = EmptyString, string colJ = EmptyString, string colK = EmptyString, string colL = EmptyString, string colM = EmptyString,
        string colN = EmptyString, string colO = EmptyString, string colP = EmptyString)
    {
        return $"{colA},{colB},{colC},{colD},{colE},{colF},{colG},{colH},{colI},{colJ},{colK},{colL},{colM},{colN},{colO},{colP}{Environment.NewLine}";
    }
}