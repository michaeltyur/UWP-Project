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
    public class GardianAppContext
    {
        private static GardianAppContext instance = null;

        public static GardianAppContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GardianAppContext();
                }
                return instance;
            }
        }

        //storage setting
        public AppSettings Settings { get; set; }

        public ObservableCollection<StoryHeader> NewsCollection { get; set; }

        private HttpService _httpService;

        private Dictionary<string, string> _parametrs;

        public StoryHeader Selected { get; set; }

        private GardianAppContext()
        {
            _httpService = new HttpService();
            _parametrs = new Dictionary<string, string>();

             NewsCollection = new ObservableCollection<StoryHeader>();
        }

        public async Task<ObservableCollection<StoryHeader>> GetAllNewsAsync()
        {
            
            NewsCollection.Clear();
            SetAllNewsParametrsDictionary();

            var result= await _httpService.GetAsync<SearchResult>(Constants.BASE_API_URL, Constants.END_POINT_SEARCH, _parametrs);
           
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

        public async Task<ObservableCollection<StoryHeader>> GetSectionAsync(string section)
        {

            NewsCollection.Clear();
            SetSectionsParametrsDictionary(section);

            var result = await _httpService.GetAsync<SearchResult>(Constants.BASE_API_URL, Constants.END_POINT_SEARCH, _parametrs);

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

        private void SetAllNewsParametrsDictionary()
        {
            _parametrs.Clear();
            _parametrs.Add(Constants.API_KEY_PARAM, Constants.API_KEY);
            _parametrs.Add(Constants.SHOW_FIELDS_PARAM, Constants.SHOW_FIELDS);
            _parametrs.Add(Constants.SHOW_ELEMENTS_PARAM, Constants.SHOW_ELEMENTS);
            _parametrs.Add(Constants.PAGE_SIZE_PARAM, Constants.PAGE_PARAM);
        }

        private void SetSectionsParametrsDictionary(string section)
        {
            _parametrs.Clear();
            _parametrs.Add(Constants.API_KEY_PARAM, Constants.API_KEY);
            _parametrs.Add(Constants.SHOW_FIELDS_PARAM, Constants.SHOW_FIELDS);
            _parametrs.Add(Constants.SHOW_ELEMENTS_PARAM, Constants.SHOW_ELEMENTS);
            _parametrs.Add(Constants.PAGE_SIZE_PARAM, Constants.PAGE_PARAM);
            _parametrs.Add("q", section);
        }


    }
}
