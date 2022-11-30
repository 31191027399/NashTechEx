using System.Collections.Generic;
using Newtonsoft.Json;

namespace DemoQA.Models.Books
{
    public class AddBookRequestDto
    {
        [JsonProperty("userId")]
        public string UserId {get; set;}
        [JsonProperty("collectionOfIsbns")]
        public List<AddBookIsbnDto> CollectionOfIsbns {get; set;}
    }
}