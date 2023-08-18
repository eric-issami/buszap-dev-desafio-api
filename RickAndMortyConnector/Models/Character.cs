using System;
using Newtonsoft.Json;

namespace RickAndMortyConnector.Models
{
	public class CharactersResult
	{
        [JsonProperty("info")]
        public Info info { get; set; }

        [JsonProperty("results")]
        public List<Character> characters { get; set; }

		public CharactersResult() { }
	}

	public class Character
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public Origin origin { get; set; }
        public Location location { get; set; }
        public string image { get; set; }
        public List<string> episode { get; set; }
        public string url { get; set; }
        public DateTime created { get; set; }

        public Character() { }
	}

    public class Origin
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
