﻿using HtmlAgilityPack;
using Pokerawler.Models;

namespace Pokerawler;

public class PokellektorExtrator
{
    private readonly HttpClient _httpClient = new ();
    
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
            var parts = info.Split('-');
            var number = parts[0].Trim();
            var name = parts[1].Trim();
            result.Add(new Pokemon(number, name));
        }

        return result;
    }

    public List<(string name, Uri uri)> DownloadSetData()
    {
        
        
        return new List<(string name, Uri uri)>();
    } 
}