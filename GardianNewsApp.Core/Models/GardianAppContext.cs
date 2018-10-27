using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GardianNewsApp.Core.Models;

namespace GardianNewsApp.Core.Models
{
    public class GardianAppContext<T>
    {

        //Singelton instance
        private static GardianAppContext<T> instance;
        public static GardianAppContext<T> Instance
        {
            get
            {
                if (instance != null) return instance;
                else return new GardianAppContext<T>();
            }
        }

       public ObservableCollection<StoryHeader> NewsCollection { get; set; }
        private HttpService _httpService;

        private Dictionary<string, string> _parametrs;
        private GardianAppContext()
        {
            _httpService = new HttpService();
            _parametrs = new Dictionary<string, string>();
            NewsCollection = new ObservableCollection<StoryHeader>();

            FillNewsCollection();
        }

        public async Task<ObservableCollection<StoryHeader>> GetAllNewsAsync()
        {
            NewsCollection.Clear();
            SetAllNewsParametrsDictionary();

            var result= await _httpService.GetAsync<T>(Constants.BASE_API_URL, Constants.END_POINT, _parametrs) as SearchResult;
           
            var collection = result.SearchResponse.StoryHeaders;
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    NewsCollection.Add(item);
                }
            }
            return NewsCollection;
        }

        private async void FillNewsCollection()
        {
            await GetAllNewsAsync();
        }

        private void SetAllNewsParametrsDictionary()
        {
            _parametrs.Clear();
            _parametrs.Add(Constants.API_KEY_PARAM, Constants.API_KEY);
            _parametrs.Add(Constants.SHOW_FIELDS_PARAM, Constants.SHOW_FIELDS);
            _parametrs.Add(Constants.SHOW_ELEMENTS_PARAM, Constants.SHOW_ELEMENTS);
            _parametrs.Add(Constants.SHOW_BLOCKS_PARAM, Constants.SHOW_BLOCKS);
        }

    }
}
