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

namespace GardianNewsApp.UWP.Settings
{

    public static class SettingsService
    {
        private const string SETTINGS_FILENAME = "settings.json";

        private static StorageFolder _settingsFolder = ApplicationData.Current.LocalFolder;

        public async static void LoadSettings()
        {
            try
            {
                StorageFile sf = await _settingsFolder.GetFileAsync(SETTINGS_FILENAME);
                if (sf == null) return;

                string content = await FileIO.ReadTextAsync(sf);
                var data = JsonConvert.DeserializeObject<AppSettings>(content);
                GardianAppContext.Instance.Settings = data;
            }
            catch (Exception ex)
            { return; }
        }

        public async static Task<bool> SaveSettings()
        {
            try
            {
                AppSettings data = GardianAppContext.Instance.Settings;
                if (data != null)
                {
                    StorageFile file = await _settingsFolder.CreateFileAsync(SETTINGS_FILENAME, CreationCollisionOption.ReplaceExisting);
                    string content = JsonConvert.SerializeObject(data);
                    await FileIO.WriteTextAsync(file, content);
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }

}
