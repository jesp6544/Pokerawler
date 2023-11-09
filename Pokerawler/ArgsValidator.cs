namespace Pokerawler;

public static class ArgsValidator
{
    public static (bool valid, List<Uri> uri) Validate(string[] args)
    {
        var uri = new List<Uri>();
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
    
    public static (bool valid, List<Uri> uri) Validate(string arg)
    {
        var uri = new List<Uri>();
        var valid = true;
        
            var argIsValidUri = Uri.TryCreate(arg, UriKind.Absolute, out var tempUri);
            if (!argIsValidUri)
            {
                SetValidAndPrint(false, "Argument is not a uri");
            }
            else
            {
                var hostIsPokelektor = tempUri!.Host.Contains("pokellector");
                uri = new List<Uri>{tempUri};
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