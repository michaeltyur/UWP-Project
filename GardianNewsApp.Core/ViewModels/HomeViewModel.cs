using GardianNewsApp.Core.Commands;
using GardianNewsApp.Core.Models;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace GardianNewsApp.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Command
        public GoToNewsDetailsCommand GoToNewsDetailsCommand { get; set; }
        public IMvxCommand NavMenuTriggerCommand { get; set; }
        public NavCommand NavCommand { get; set; }

        //Binding proprietes
        public string PageTitle { get; set; }
        private  bool isPaneOpen;
        public  bool IsPaneOpen
        {
            get { return isPaneOpen; }
            set { isPaneOpen = value; OnPropertyChanged(); }
        }
        public StoryHeader Selected
        {
            get { return GardianAppContext.Instance.Selected; }
            set { GardianAppContext.Instance.Selected = value; }
        }
        private ObservableCollection<StoryHeader> newsCollection;
        public ObservableCollection<StoryHeader> NewsCollection
        {
            get { return newsCollection; }
            set { newsCollection = value;OnPropertyChanged(); }
        }

        private GardianAppContext appContext;

        //Progress Ring
        private bool progressRingIsActive;
        public bool ProgressRingIsActive
        {
            get { return progressRingIsActive; }
            set { progressRingIsActive = value;OnPropertyChanged(); }
        }
        private bool progressRingVisibility;
        public bool ProgressRingVisibility
        {
            get { return progressRingVisibility; }
            set { progressRingVisibility = value; OnPropertyChanged(); }
        }

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            appContext = GardianAppContext.Instance;

            appContext.Settings = new AppSettings("All News", string.Empty);


            //Command
            GoToNewsDetailsCommand = new GoToNewsDetailsCommand(navigationService);
            NavMenuTriggerCommand = new MvxCommand(NavPanelTrigger);
            NavCommand = new NavCommand(navigationService);


            PageTitle = "All News";

            NewsCollection = new ObservableCollection<StoryHeader>();
            SetNewsCollectionAsync();
            ProgressRingIsActive = true;
            ProgressRingVisibility = true;
        }
        private void NavPanelTrigger()
        {
            IsPaneOpen = !IsPaneOpen;
        }
        private async void SetNewsCollectionAsync()
        {
               NewsCollection = await appContext.GetAllNewsAsync();
               ProgressRingIsActive = false;
               ProgressRingVisibility = false;     
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Share(StoryHeader story)
        {

        }
    }
}
