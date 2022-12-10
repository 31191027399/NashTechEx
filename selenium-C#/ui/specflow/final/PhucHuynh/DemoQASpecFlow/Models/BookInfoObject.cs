using Newtonsoft.Json;

namespace DemoQASpecFlow.Models
{
    public class BookInfoObject
    {
        
        [JsonProperty("isbn")]
        public string Isbn { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("subTitle")]
        public string SubTitle { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("publish_date")]
        public string Publish_date { get; set; }
        [JsonProperty("publisher")]
        public string Publisher { get; set; }
        [JsonProperty("pages")]
        public string Pages { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
    }
}