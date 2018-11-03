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

        public async Task<T> GetAsync<T>(string baseUrl, Dictionary<string, string> parameters)
        {
            using (var client = new HttpClient())
            {
                var finalUrl = baseUrl + GetParametersString(parameters);

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
