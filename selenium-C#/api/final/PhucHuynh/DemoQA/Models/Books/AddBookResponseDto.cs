using Newtonsoft.Json;
using System.Collections.Generic;
namespace DemoQA.Models.Books
{
    public class AddBookResponseDto
    {
        [JsonProperty("books")]
        public List<AddBookIsbnDto> Books {get; set;}
    }
}