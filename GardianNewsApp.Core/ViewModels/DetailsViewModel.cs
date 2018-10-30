using GardianNewsApp.Core.Commands;
using GardianNewsApp.Core.Models;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GardianNewsApp.Core.ViewModels
{
   public class DetailsViewModel : MvxViewModel<string>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public IMvxCommand NavMenuTriggerCommand { get; set; }
        public NavCommand NavCommand { get; set; }

        public string Html { get; set; }
        public string PageTitle { get; set; }
        private bool isPaneOpen;
        public bool IsPaneOpen
        {
            get { return isPaneOpen; }
            set { isPaneOpen = value; OnPropertyChanged(); }
        }

        public DetailsViewModel(IMvxNavigationService navigationService)
        {
         

            //Commands
            NavMenuTriggerCommand = new MvxCommand(NavPanelTrigger);
            NavCommand = new NavCommand(navigationService);

            PageTitle = "Details";
            Html = GardianAppContext.Instance.Settings.UrlSettings;
        }

        public override void Prepare()
        {
            // first callback. Initialize parameter-agnostic stuff here
        }

        public override void Prepare(string parameter)
        {
            // receive and store the parameter here
            Html = parameter;

            var appContext = GardianAppContext.Instance;

            appContext.Settings = new AppSettings("Details",Html) ;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
          
        }

        private void NavPanelTrigger()
        {
            IsPaneOpen = !IsPaneOpen;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

