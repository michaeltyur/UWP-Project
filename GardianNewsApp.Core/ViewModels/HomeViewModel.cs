using GardianNewsApp.Core.Commands;
using GardianNewsApp.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace GardianNewsApp.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public GoToNewsDetailsCommand GoToNewsDetailsCommand { get; set; }

        public StoryHeader SelectedItem
        {
            get { return appContext.SelectedItem; }
            set { appContext.SelectedItem = value; OnPropertyChanged (); }
        }

        private ObservableCollection<StoryHeader> newsCollection;
        public ObservableCollection<StoryHeader> NewsCollection
        {
            get { return newsCollection; }
            set { newsCollection = value;OnPropertyChanged(); }
        }

        private GardianAppContext<SearchResult> appContext;

        
        //public IMvxCommand GoToDetailsCommand { get; set; }

        //Progress Ring
        private bool progressRingIsActive;
        public bool ProgressRingIsActive
        {
            get { return progressRingIsActive; }
            set { progressRingIsActive = value;OnPropertyChanged(); }
        }
        private Visibility progressRingVisibility;
        public Visibility ProgressRingVisibility
        {
            get { return progressRingVisibility; }
            set { progressRingVisibility = value; OnPropertyChanged(); }
        }

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            appContext = GardianAppContext<SearchResult>.Instance;
            appContext.MvxNavigation = navigationService;

            NewsCollection = new ObservableCollection<StoryHeader>();
            SetNewsCollectionAsync();
            ProgressRingIsActive = true;
            ProgressRingVisibility = Visibility.Visible;

        }

        public override void Prepare()
        {
            // first callback. Initialize parameter-agnostic stuff here
        }

        //public async void GoToNewsDetails()
        //{
        //   var result = await _navigationService.Navigate< DetailsViewModel, string>(SelectedItem.ApiUrl);
        //}

        private async void SetNewsCollectionAsync()
        {
               NewsCollection = await appContext.GetAllNewsAsync();
               ProgressRingIsActive = false;
               ProgressRingVisibility = Visibility.Collapsed;       
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
