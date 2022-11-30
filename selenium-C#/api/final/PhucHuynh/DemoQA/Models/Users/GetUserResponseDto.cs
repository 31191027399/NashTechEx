using System.Collections.Generic;
using Newtonsoft.Json;
using DemoQA.Models.Users;

namespace DemoQA.Models.Users
{
    public class GetUserResponseDto
    {
     [JsonProperty("userId")]
     public string UserId {get; set;}
     [JsonProperty("userName")]
     public string UserName {get; set;}
     [JsonProperty("books")]
     public IList<BookInfoInUserProfileDto> Books {get; set;}
    }
}