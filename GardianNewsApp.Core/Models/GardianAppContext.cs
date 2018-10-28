using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GardianNewsApp.Core.Commands;
using GardianNewsApp.Core.Models;
using GardianNewsApp.Core.ViewModels;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace GardianNewsApp.Core.Models
{
    public class GardianAppContext<T>
    {
       public MvxCommand GoToDetailsCommand { get; set; }
       public IMvxNavigationService MvxNavigation { get; set; }

        public StoryHeader SelectedItem { get; set; }

        //Singelton instance
        private static GardianAppContext<T> instance;
        public static GardianAppContext<T> Instance
        {
            get
            {
                return instance ?? (instance = new GardianAppContext<T>());
            }
        }

        public string NewsDetails { get; set; }

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
