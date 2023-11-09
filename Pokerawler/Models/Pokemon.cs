namespace Pokerawler.Models;

public class Pokemon
{
    public Pokemon(string number, string name)
    {
        Number = number;
        Name = name;
    }
    public string Number { get; set; }
    public string Name { get; set; }
}