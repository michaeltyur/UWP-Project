using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace GardianNewsApp.Core.ViewModels
{
   public class DetailsViewModel : MvxViewModel<string>, INotifyPropertyChanged
    {
        public string Html { get; set; }

        public DetailsViewModel()
        {
            
        }
        public override void Prepare()
        {
            // first callback. Initialize parameter-agnostic stuff here
        }

        public override void Prepare(string parameter)
        {
            // receive and store the parameter here
            Html = parameter;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            // do the heavy work here
        }
    }
}

