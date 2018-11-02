using System;
using System.Collections.Generic;
using System.Text;

namespace GardianNewsApp.Core.Models
{

    public class AppSettings
    {
        public string PageSettings { get; set; }
        public string IdSettings { get; set; }

        public AppSettings(string page,string id)
        {
            PageSettings = page;
            IdSettings = id;
        }
    }
}
