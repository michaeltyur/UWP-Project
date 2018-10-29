using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardianNewsApp.Core.ViewModels
{
    public class MainPageViewModel : MvxViewModel
    {
        public string PageTitle { get; set; }

        public MainPageViewModel()
        {
            PageTitle = "Main Page";
        }
    }
}
