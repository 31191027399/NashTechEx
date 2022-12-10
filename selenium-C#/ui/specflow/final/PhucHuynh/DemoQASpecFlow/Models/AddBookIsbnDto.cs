using System.Threading.Tasks.Dataflow;
using Newtonsoft.Json;

namespace DemoQASpecFlow.Models
{
    public class AddBookIsbnDto
    {
        [JsonProperty("isbn")]
        public string Isbn {get;set;}
    }
}