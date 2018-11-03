using GardianNewsApp.Core.Models;
using Newtonsoft.Json;

namespace GardianNewsApp.Core.Models
{
    public class SearchResult
    {
        [JsonProperty(PropertyName = "response")]
        public SearchResponse SearchResponse { get; set; }

       
    }

}