using GardianNewsApp.Core.Commands;
using GardianNewsApp.Core.Interfaces;
using GardianNewsApp.Core.Models;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GardianNewsApp.Core.ViewModels
{
    public class SectionViewModel : MvxViewModel<string>,IMvxNotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Command
        public GoToNewsDetailsCommand GoToNewsDetailsCommand { get; set; }
        public IMvxCommand NavMenuTriggerCommand { get; set; }
        public NavCommand NavCommand { get; set; }
        public ShareCommand ShareCommand { get; set; }

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

        private ObservableCollection<StoryHeader> newsCollection;
        public ObservableCollection<StoryHeader> NewsCollection
        {
            get { return newsCollection; }
            set { newsCollection = value; OnPropertyChanged(); }
        }

        public SectionViewModel(IMvxNavigationService navigationService)
        {
            //Command
            GoToNewsDetailsCommand = new GoToNewsDetailsCommand(navigationService);
            NavMenuTriggerCommand = new MvxCommand(NavPanelTrigger);
            NavCommand = new NavCommand(navigationService);
            ShareCommand = new ShareCommand();

            PageTitle = Mvx.IoCProvider.GetSingleton<GardianAppContext>().Settings.PageSettings;
            ProgressRingIsActive = true;
            ProgressRingVisibility = true;
            InitializeSectionNewsCollection();

            //Save settings

        }
        private void NavPanelTrigger()
        {
            IsPaneOpen = !IsPaneOpen;
        }
        public override void Prepare(string parameter)
        {
        }

        public override async Task Initialize()
        {

            await base.Initialize();

        }
        private async void InitializeSectionNewsCollection()
        {
            var _parameter = PageTitle;
            _parameter = _parameter.ToLower().Replace(" ", "");
            NewsCollection = await Mvx.IoCProvider.GetSingleton<GardianAppContext>().GetSectionAsync(_parameter);
            
            ProgressRingIsActive = false;
            ProgressRingVisibility = false;
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SaveSaveSettings(AppSettings settings)
        {
            var settingProvider = Mvx.IoCProvider.GetSingleton<ISettings>();
            settingProvider.SaveSettings(settings);
        }
    }
}
