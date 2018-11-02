using GardianNewsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GardianNewsApp.Core.Interfaces
{
   public interface ISettings
    {      
            
            void SaveSettings(AppSettings appSettings);

            Task<AppSettings> LoadSettings();
    }
}
