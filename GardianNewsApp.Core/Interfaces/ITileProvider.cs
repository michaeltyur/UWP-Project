using System;
using System.Collections.Generic;
using System.Text;

namespace GardianNewsApp.Core.Interfaces
{
    public interface ITileProvider
    {
         
         void CreateSecondaryTileAsync(string articleTitle, string trailText);
    }
}
