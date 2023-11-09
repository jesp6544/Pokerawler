// See https://aka.ms/new-console-template for more information

using Pokerawler;

var argIsAccepted = false;
var validationResult = (false, new Uri("https://example.com"));

if (args.Any())
{
    validationResult = ArgsValidator.Validate(args);
}
else
{
    while (!argIsAccepted)
    {
        Console.WriteLine("Input pokellector link");
        var input = Console.ReadLine();
        
        validationResult = ArgsValidator.Validate(input ?? string.Empty);
        argIsAccepted = validationResult.Item1;
    }
}

if (!validationResult.Item1) return;

var extrator = new PokellektorExtrator();
var resultingPokemon = extrator.PerformWork(validationResult.Item2);

PokemonToCsvSaver.Persist(resultingPokemon);