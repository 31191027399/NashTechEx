using System.Threading.Tasks.Dataflow;
using Newtonsoft.Json;

namespace DemoQA.Models.Books
{
    public class AddBookIsbnDto
    {
        [JsonProperty("isbn")]
        public string Isbn {get;set;}
    }
}