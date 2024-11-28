using HtmlAgilityPack;
using Pokerawler.Models;

namespace Pokerawler;

public class PokellektorExtrator
{
    private readonly HttpClient _httpClient = new ();
    private readonly Uri _pokellectorSetUrl = new ("https://www.pokellector.com/sets");
    
    public List<Pokemon> DownloadSetFromUri(Uri uri)
    {
        var result = new List<Pokemon>();
        
        var html = _httpClient.GetStringAsync(uri).Result;
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);
        var list = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'plaque')]");
        foreach (var element in list)
        {
            var info = element.InnerHtml;
            var indexOfSpace = info.IndexOf(' ');
            var number = info.Substring(0, indexOfSpace);
            var name = info.Substring(indexOfSpace + 3);
            
            result.Add(new Pokemon(number, name));
        }

        return result;
    }

    public List<(string name, Uri uri)> DownloadSetData()
    {
        var result = new List<(string name, Uri uri)>();
        var html = _httpClient.GetStringAsync(_pokellectorSetUrl).Result;
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);
        var setGroupings = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'buttonlisting')]");
        foreach (var setGroup in setGroupings)
        {
            var sets = setGroup.Descendants().Where(d => d.HasClass("button"));
            foreach (var set in sets)
            {
                var name = set.InnerText;
                var href = set.Attributes.Single(a => a.Name == "href").Value;
                var link = new Uri($"https://www.pokellector.com{href}");
                result.Add((name, link));
            }
        }
        return result;
    } 
}