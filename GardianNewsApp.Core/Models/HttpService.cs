﻿using GardianNewsApp.Core.ViewModels;
using MvvmCross.Navigation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GardianNewsApp.Core.Models
{

    public class HttpService
    {
        IMvxNavigationService _navigationService;
        public HttpService()
        {
            _navigationService = MvvmCross.IoC.MvxIoCProvider.Instance.GetSingleton<IMvxNavigationService>();
        }
        public async Task<T> GetAsync<T>(string baseUrl, Dictionary<string, string> parameters)
        {
            
            using (var client = new HttpClient())
            {
                var finalUrl = baseUrl + GetParametersString(parameters);
                try
                {
                   
                    var response = await client.GetAsync(finalUrl);
                    var result = response.StatusCode;
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //response.EnsureSuccessStatusCode();

                        var resultJson = await response.Content.ReadAsStringAsync();
                        var resulObj = JsonConvert.DeserializeObject<T>(resultJson);
                        return resulObj;
                    }
                    else return default(T);

                }
                catch (Exception ex)
                {
                    if (ex.Message == "An error occurred while sending the request.")
                    {
                       await  _navigationService.Navigate<ErrorViewModel, string>("Sorry, Close the aplication and chack your internet connection.");
                        return default(T);
                    }
                    return default(T);
                }
            }
        }

        private string GetParametersString(Dictionary<string, string> parameters)
        {
            if (parameters?.Any() != true)
                return string.Empty;

            var parametersString = new StringBuilder("?");
            foreach (var parameter in parameters)
            {
                parametersString.Append($"{parameter.Key}={parameter.Value}&");
            }

            parametersString.Remove(parametersString.Length - 1, 1);//remove first symbol '$'

            return parametersString.ToString();
        }
    }
}
