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
        public ShareCommand ShareCommand { get; set; }

        private GardianAppContext appContext;

        private StoryHeader selected;
        public StoryHeader Selected
        {
            get { return selected; }
            set { selected = value;OnPropertyChanged(); }
        }

        public string PageTitle { get; set; }
        private bool isPaneOpen;
        public bool IsPaneOpen
        {
            get { return isPaneOpen; }
            set { isPaneOpen = value; OnPropertyChanged(); }
        }

        //Progress Ring
        private bool progressRingIsActive;
        public bool ProgressRingIsActive
        {
            get { return progressRingIsActive; }
            set { progressRingIsActive = value; OnPropertyChanged(); }
        }
        private bool progressRingVisibility;
        public bool ProgressRingVisibility
        {
            get { return progressRingVisibility; }
            set { progressRingVisibility = value; OnPropertyChanged(); }
        }

        public DetailsViewModel(IMvxNavigationService navigationService)
        {

            // receive and store the parameter here
            appContext = Mvx.IoCProvider.GetSingleton<GardianAppContext>();
            appContext.SaveSettings(appContext.Settings);

            //Commands
            NavMenuTriggerCommand = new MvxCommand(NavPanelTrigger);
            NavCommand = new NavCommand(navigationService);
            ShareCommand = new ShareCommand();

            PageTitle = "Details";


        }

        private async void InitializeSelectedItem()
        {
            var _parameter = appContext.Settings.IdSettings;
            Selected = await appContext.GetSingleItemAsync(_parameter);

            ProgressRingIsActive = false;
            ProgressRingVisibility = false;
        }

        public override void Prepare(string parameter)
        {
            var appContext = Mvx.IoCProvider.GetSingleton<GardianAppContext>();
            appContext.Settings = new AppSettings(PageTitle, parameter);
            appContext.SaveSettings(appContext.Settings);
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

