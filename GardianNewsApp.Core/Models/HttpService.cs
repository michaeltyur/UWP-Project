﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GardianNewsApp.Core.Models
{

    public class HttpService
    {
  
        public async Task<T> GetAsync<T>(string baseUrl, string endPoint, Dictionary<string, string> parameters)
        {
            using (var client = new HttpClient())
            {
                var finalUrl = baseUrl + endPoint + GetParametersString(parameters);

                var response = await client.GetAsync(finalUrl);
                response.EnsureSuccessStatusCode();

                var resultJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(resultJson);
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
