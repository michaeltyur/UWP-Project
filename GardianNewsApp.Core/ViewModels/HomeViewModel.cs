using GardianNewsApp.Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.UI.Xaml;

namespace GardianNewsApp.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private ObservableCollection<StoryHeader> newsCollection;
        public ObservableCollection<StoryHeader> NewsCollection
        {
            get { return newsCollection; }
            set { newsCollection = value;OnPropertyChanged(); }
        }

        private GardianAppContext<SearchResult> appContext;

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

        public HomeViewModel()
        {
            appContext = GardianAppContext<SearchResult>.Instance;
            NewsCollection = new ObservableCollection<StoryHeader>();
            SetNewsCollectionAsync();
            ProgressRingIsActive = true;
            ProgressRingVisibility = Visibility.Visible;

        }
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
