using Newtonsoft.Json;
namespace DemoQA.Models.Users
{
    public class UserInfoAddToGetTokenDto
    {
        [JsonProperty("userName")]
        public string UserName {get;set;}
        [JsonProperty("password")]
        public string Password{get;set;}
    }
}