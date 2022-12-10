using System.Collections.Generic;
using Newtonsoft.Json;

namespace DemoQASpecFlow.Models
{
    public class AllBooksInfoObject
    {
        [JsonProperty("books")]
        public BookInfoObject[] Books {get;set;}
    }
}