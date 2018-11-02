using GardianNewsApp.Core.Commands;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using Newtonsoft.Json;
using System;

namespace GardianNewsApp.Core.Models
{
    public class StoryHeader
    {
        //public GoToNewsDetailsCommand GoToDetailsCommand { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        //[JsonProperty(PropertyName = "type")]
        //public string Type { get; set; }
        [JsonProperty(PropertyName = "sectionId")]
        public string SectionId { get; set; }

        [JsonProperty(PropertyName = "sectionName")]
        public string SectionName { get; set; }

        [JsonProperty(PropertyName = "webPublicationDate")]
        public DateTime WebPublicationDate { get; set; }

        [JsonProperty(PropertyName = "webTitle")]
        public string WebTitle { get; set; }

        [JsonProperty(PropertyName = "webUrl")]
        public string WebUrl { get; set; }

        [JsonProperty(PropertyName = "apiUrl")]
        public string ApiUrl { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public StoryHeaderAdditionalFields StoryHeaderAdditionalFields { get; set; }

         public ShareObject ShareObject
        {
            get { return new ShareObject { Url = WebUrl,Title= WebTitle }; }
            set { }
        }

        [JsonProperty(PropertyName = "blocks")]
        public Blocks Blocks { get; set; }

    }
}
