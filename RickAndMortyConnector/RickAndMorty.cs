using System.Linq;
using Newtonsoft.Json;
using RickAndMortyConnector.Miscellaneous;
using RickAndMortyConnector.Models;

namespace RickAndMortyConnector;

public class RickAndMorty : IDisposable
{
    private Resources resources;

    public RickAndMorty()
    {
        GetResources();
    }

    /// <summary>
    /// Consulta os endpoints dos serviços disponíveis
    /// </summary>
    public void GetResources()
    {
        string baseUrl = "https://rickandmortyapi.com/api";

        using (RestfulApi restfulApi = new RestfulApi())
        {
            resources = JsonConvert.DeserializeObject<Resources>(restfulApi.Get(baseUrl).ToString());
        }
     }

    /// <summary>
    /// Consulta os prosonagens, permitindo utilizar parametros de consulta
    ///
    /// Filtros
    /// episodeCount
    /// 0 -> indiferente
    /// 1 -> apareceu em apenas 1 episódio
    /// 2 -> apareceu em 2 ou mais episódios
    /// </summary>
    public List<Character> GetCharacters(string _status = "unknown", string _species = "Alien", byte _episodeCount = 2)
    {
        string endpoint = resources.charactersURL;
        string filter = $"?status={_status}&species={_species}";
        List<Character> characters = new List<Character>();

        using (RestfulApi restfulApi = new RestfulApi())
        {
            CharactersResult baseResult = new CharactersResult();

            baseResult = JsonConvert.DeserializeObject<CharactersResult>(restfulApi.Get(endpoint + filter).ToString());

            if (baseResult != null)
            {
                characters.AddRange(baseResult.characters.Where(x => _episodeCount == 0 ? x != null : (_episodeCount == 1 ? x.episode.Count == 1 : x.episode.Count > 1)));

                string nextPage = baseResult.info.next;

                while (!String.IsNullOrEmpty(nextPage))
                {
                    baseResult = JsonConvert.DeserializeObject<CharactersResult>(restfulApi.Get(baseResult.info.next).ToString());
                    nextPage = baseResult.info.next;
                    characters.AddRange(baseResult.characters.Where(x => _episodeCount == 0 ? x != null : (_episodeCount == 1 ? x.episode.Count == 1 : x.episode.Count > 1)));
                }
            }
        }

        return characters;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
