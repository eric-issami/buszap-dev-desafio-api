using System;
using Newtonsoft.Json;

namespace RickAndMortyConnector.Models
{
	public class Resources
    {
        [JsonProperty("characters")]
        public string charactersURL { get; set; }

        [JsonProperty("locations")]
        public string locationsURL { get; set; }

        [JsonProperty("episodes")]
        public string episodesURL { get; set; }
        
        public Resources()
		{
		}
	}
}

