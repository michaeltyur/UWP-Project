using GardianNewsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardianNewsApp.Core.Interfaces
{
    public interface ITileProvider
    {
         
         void TileUpdater(string category, string content);
    }
}
