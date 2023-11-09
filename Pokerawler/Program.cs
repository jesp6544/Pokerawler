// See https://aka.ms/new-console-template for more information

using Pokerawler;

var argIsAccepted = false;
var validationResult = (false, new List<Uri>{new ("https://example.com")});
var downloader = new Downloader();

if (args.Any())
{
    validationResult = ArgsValidator.Validate(args);
}
else
{
    while (!argIsAccepted)
    {
        Console.WriteLine("Input pokellector link or press 1 to download all sets");
        var input = Console.ReadLine();

        if ((input ?? string.Empty) == "1")
        {
            Console.WriteLine("Downloading all sets!");

            downloader.DownloadAll();
            
            return;
        }
        
        validationResult = ArgsValidator.Validate(input ?? string.Empty);
        argIsAccepted = validationResult.Item1;
    }
}

downloader.DownloadSingle(validationResult.Item2.Single());
