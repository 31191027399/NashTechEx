using Newtonsoft.Json;

namespace DemoQA.Models.Users
{
    public class GetUserTokenDto
    {
        [JsonProperty("token")]
        public string Token {get; set;}
        [JsonProperty("expires")]
        public string Expires {get; set;}
        [JsonProperty("status")]
        public string Status {get; set;}
        [JsonProperty("result")]
        public string Result {get; set;}

    }
}