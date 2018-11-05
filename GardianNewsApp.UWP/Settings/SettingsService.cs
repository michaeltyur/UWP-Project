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
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace GardianNewsApp.UWP.Settings
{

    public class SettingsService : ISettings
    {

        private const string SETTINGS_FILENAME = "settings.json";

        private StorageFolder _settingsFolder = ApplicationData.Current.LocalFolder;

        private bool _result;

        public async Task<AppSettings> LoadSettings()
        {
            try
            {
                StorageFile sf = await _settingsFolder.GetFileAsync(SETTINGS_FILENAME);
                if (sf == null) return null;

                string content = await FileIO.ReadTextAsync(sf);
                var data = JsonConvert.DeserializeObject<AppSettings>(content);
                if (data!=null)
                {
                }
                
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async void SaveSettings(AppSettings appSettings)
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

        public async void ShowDialogAsync()
        {

            bool result;
            var messageDialog = new MessageDialog("Gurdian Aplication Start");
            messageDialog.Content = "Do you want to start from previous page?";

            messageDialog.Commands.Add(new UICommand("Previous Page") { Id = 0, Invoked =(IUICommand command) => { result = true; } });
            messageDialog.Commands.Add(new UICommand("Start Page") { Id = 1, Invoked = (IUICommand command) => { result = false; } });


            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 1;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await  messageDialog.ShowAsync();
        }
        private async void DisplayNoWifiDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "No wifi connection",
                Content = "Check connection and try again.",
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();
        }
        private void CommandInvokedHandler(IUICommand command)
        {

            _result = ((int)command.Id == 0) ? true:false;
        }
    }
}
