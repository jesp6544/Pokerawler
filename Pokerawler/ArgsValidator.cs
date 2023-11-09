namespace Pokerawler;

public static class ArgsValidator
{
    public static (bool valid, Uri uri) Validate(string[] args)
    {
        var uri = new Uri("https://example.com");
        var valid = true;
        if (args.Length != 1)
        {
            SetValidAndPrint(false, "Needs 1 argument");
        }
        else
        {
            return Validate(args.Single());
        }

        return (valid, uri);

        void SetValidAndPrint(bool validValue, string message)
        {
            valid = validValue;
            if (!string.IsNullOrWhiteSpace(message)) Console.WriteLine(message);
        }
    }
    
    public static (bool valid, Uri uri) Validate(string arg)
    {
        var uri = new Uri("https://example.com");
        var valid = true;
        
            var argIsValidUri = Uri.TryCreate(arg, UriKind.Absolute, out var tempUri);
            if (!argIsValidUri)
            {
                SetValidAndPrint(false, "Argument is not a uri");
            }
            else
            {
                uri = tempUri!;
                var hostIsPokelektor = uri.Host.Contains("pokellector");
                if (!hostIsPokelektor)
                {
                    SetValidAndPrint(false, "Can only parse pokelektor links");

                }
            }

        return (valid, uri);

        void SetValidAndPrint(bool validValue, string message)
        {
            valid = validValue;
            if (!string.IsNullOrWhiteSpace(message)) Console.WriteLine(message);
        }
    }
}