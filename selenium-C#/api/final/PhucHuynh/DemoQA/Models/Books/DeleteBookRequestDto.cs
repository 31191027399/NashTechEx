using Newtonsoft.Json;
using System.Collections.Generic;

namespace DemoQA.Models.Books
{
    public class DeleteBookRequestDto
    {

        [JsonProperty("isbn")]
        public string Isbn { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }

    }
}