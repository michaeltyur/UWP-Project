using System;
using System.Collections.Generic;
using System.Text;

namespace GardianNewsApp.Core.Interfaces
{
   public interface ISettings
    {
       
            object this[string propertyName] { get; set; }

            void Save();
        
    }
}
