﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GardianNewsApp.Core.Commands;
using GardianNewsApp.Core.Interfaces;
using GardianNewsApp.Core.Models;
using GardianNewsApp.Core.ViewModels;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace GardianNewsApp.Core.Models
{
    public class GardianAppContext
    {
        //storage setting
        public AppSettings Settings { get; set; }

        public ObservableCollection<StoryHeader> NewsCollection { get; set; }

        private HttpService _httpService;

        private Dictionary<string, string> _parametrs;

        public StoryHeader Selected { get; set; }

        public GardianAppContext(HttpService httpService)
        {
            _httpService = httpService;
            _parametrs = new Dictionary<string, string>();

            NewsCollection = new ObservableCollection<StoryHeader>();
        }
        public async Task<ObservableCollection<StoryHeader>> GetAllNewsAsync()
        {

            NewsCollection.Clear();
            SetAllNewsParametersDictionary();

            var result = await _httpService.GetAsync<SearchResult>(Constants.BASE_API_URL_SEARCH, _parametrs);
            if (result != null)
            {
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
            else return null;
        }

        public async Task<ObservableCollection<StoryHeader>> GetSectionAsync(string section)
        {

            NewsCollection.Clear();
            SetSectionsParametersDictionary(section);

            var result = await _httpService.GetAsync<SearchResult>(Constants.BASE_API_URL_SEARCH, _parametrs);
            if (result != null)
            {
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
            else return null;
        }

        public async Task<StoryHeader> GetSingleItemAsync(string id)
        {
            SetSingleItemParametersDictionary();

            var adress = Constants.BASE_API_URL + id;
            var result = await _httpService.GetAsync<SearchResult>(adress, _parametrs);
            if (result != null)
            {
                Selected = result.SearchResponse.StoryHeader;
            }

            return Selected;
        }

        
        /// <summary>
        /// Saves Current Page for furthered start
        /// </summary>
        /// <param name="settings">current page name string</param>
        public void SaveSettings(AppSettings settings)
        {
            var settingsProvider = Mvx.IoCProvider.GetSingleton<ISettings>();
            settingsProvider.SaveSettings(settings);
        }

        public void CreateSecondaryTileAsync()
        {
            Random random = new Random();
            var randomNews = random.Next(NewsCollection.Count);
            var tileProvider = Mvx.IoCProvider.GetSingleton<ITileProvider>();
            SecondTile secondTile = new SecondTile();
            if (NewsCollection.Count > 0)
            {
                tileProvider.TileUpdater(NewsCollection[randomNews].SectionName, 
                                         NewsCollection[randomNews].WebTitle);
            }
        }

        public async Task<AppSettings> LoadSettings()
        {
            var settingsProvider = Mvx.IoCProvider.GetSingleton<ISettings>();
            return await settingsProvider.LoadSettings();
        }

        private void SetAllNewsParametersDictionary()
        {
            _parametrs.Clear();
            _parametrs.Add(Constants.API_KEY_PARAM, Constants.API_KEY);
            _parametrs.Add(Constants.SHOW_FIELDS_PARAM, Constants.SHOW_FIELDS_All);
            _parametrs.Add(Constants.SHOW_ELEMENTS_PARAM, Constants.SHOW_ELEMENTS);
            _parametrs.Add(Constants.PAGE_SIZE_PARAM, Constants.PAGE_PARAM);
        }

        private void SetSectionsParametersDictionary(string section)
        {
            _parametrs.Clear();
            _parametrs.Add("q", section);
            _parametrs.Add(Constants.API_KEY_PARAM, Constants.API_KEY);
            _parametrs.Add(Constants.SHOW_FIELDS_PARAM, Constants.SHOW_FIELDS_All);
            _parametrs.Add(Constants.SHOW_ELEMENTS_PARAM, Constants.SHOW_ELEMENTS);
        }

        private void SetSingleItemParametersDictionary()
        {
            _parametrs.Clear();
            _parametrs.Add(Constants.API_KEY_PARAM, Constants.API_KEY);
            _parametrs.Add(Constants.SHOW_FIELDS_PARAM, Constants.SHOW_FIELDS_All);
        }
    }
}
