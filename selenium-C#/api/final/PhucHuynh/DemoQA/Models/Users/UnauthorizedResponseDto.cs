using Newtonsoft.Json;
namespace DemoQA.Models.Users
{
    public class UnauthorizedResponseDto
    {
        [JsonProperty("code")]
        public string Code {get;set;}
        [JsonProperty("message")]
        public string Message {get;set;}
    }
}
