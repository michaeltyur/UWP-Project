using Newtonsoft.Json;

namespace GardianNewsApp.Core.Models
{
    public class StoryHeaderAdditionalFields
    {
        [JsonProperty(PropertyName = "trailText")]
        public string TrailText { get; set; }

        private string thumbnail;
        [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail
        {
            get { return thumbnail; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    thumbnail = "https://www.dollsdepartment25.nl/files/4667/editor/images/Clips%20en%20promoplaatjes/Temporary_not_available.jpg";
                }
                else thumbnail = value;
            }
        }
    }

}