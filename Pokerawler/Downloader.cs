namespace Pokerawler;

public class Downloader
{
    private readonly PokellektorExtrator _extrator = new ();
    
    public Downloader()
    {
    }

    public void DownloadAll()
    {
        var sets = _extrator.DownloadSetData();

        foreach (var set in sets)
        {
            var resultingPokemon = _extrator.DownloadSetFromUri(set.uri);

            PokemonToCsvSaver.Persist(resultingPokemon, set.name);
        }
    }
    
    public void DownloadSingle(Uri uri)
    {
        var resultingPokemon = _extrator.DownloadSetFromUri(uri);

        PokemonToCsvSaver.Persist(resultingPokemon);
    }
}