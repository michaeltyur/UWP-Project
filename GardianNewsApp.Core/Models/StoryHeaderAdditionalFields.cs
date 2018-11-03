using Newtonsoft.Json;

namespace GardianNewsApp.Core.Models
{
    public class StoryHeaderAdditionalFields
    {
        [JsonProperty(PropertyName = "trailText")]
        public string TrailText { get; set; }
       
         [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail { get; set; }
      

        [JsonProperty(PropertyName = "bodyText")]
        public string BodyText { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }


    }

}