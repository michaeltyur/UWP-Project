using System;
using System.Collections.Generic;
using System.Text;

namespace GardianNewsApp.Core.Interfaces
{
    public interface IShare
    {
        void Share(string articleTitle, string url);
    }
}
