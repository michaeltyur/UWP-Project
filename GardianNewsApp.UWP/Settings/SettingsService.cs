using GardianNewsApp.Core.Models;
using MvvmCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using GardianNewsApp.Core.Models;
using Newtonsoft.Json;
using GardianNewsApp.Core.Interfaces;

namespace GardianNewsApp.UWP.Settings
{

    public class SettingsService:ISettings
    {
        private const string SETTINGS_FILENAME = "settings.json";

        private  StorageFolder _settingsFolder = ApplicationData.Current.LocalFolder;

        //public object this[string propertyName] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<AppSettings> LoadSettings()
        {
            try
            {
                StorageFile sf = await _settingsFolder.GetFileAsync(SETTINGS_FILENAME);
                if (sf == null) return null;

                string content = await FileIO.ReadTextAsync(sf);
                var data = JsonConvert.DeserializeObject<AppSettings>(content);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async  void SaveSettings(AppSettings appSettings)
        {
            try
            {
                AppSettings data = appSettings;
                if (data != null)
                {
                    StorageFile file = await _settingsFolder.CreateFileAsync(SETTINGS_FILENAME, CreationCollisionOption.ReplaceExisting);
                    string content = JsonConvert.SerializeObject(data);
                    await FileIO.WriteTextAsync(file, content);
                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }

}
