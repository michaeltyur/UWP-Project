namespace GardianNewsApp.Core.Models
{
    public class Constants
    {
        public const string BASE_API_URL = "https://content.guardianapis.com/";
        public const string END_POINT_SEARCH = "search";
        public const string END_POINT_SECTION = "section";

        public const string API_KEY_PARAM = "api-key";
        public const string API_KEY = "6e094816-d879-46d7-ae1b-a8c0ad2aa647";

        public const string SHOW_FIELDS_PARAM = "show-fields";
        public const string SHOW_FIELDS = "thumbnail,trailText";

        public const string SHOW_ELEMENTS_PARAM = "show-elements";
        public const string SHOW_ELEMENTS = "image";

        public const string SHOW_BLOCKS_PARAM = "show-blocks";
        public const string SHOW_BLOCKS = "body:latest:20"; 

        public const string PAGE_SIZE_PARAM = "page-size";
        public const string PAGE_PARAM = "20";

    }
}
    public enum Pages
    {
            All_News=1,
             Football,
              Animals,
       Art_And_Design,
                Books,
       Australia_News,
              Culture,
               Details
    }
