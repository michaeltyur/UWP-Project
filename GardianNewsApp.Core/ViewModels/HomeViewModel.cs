﻿using GardianNewsApp.Core.Commands;
using GardianNewsApp.Core.Interfaces;
using GardianNewsApp.Core.Models;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GardianNewsApp.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Command
        public GoToNewsDetailsCommand GoToNewsDetailsCommand { get; set; }
        public IMvxCommand NavMenuTriggerCommand { get; set; }
        public NavCommand NavCommand { get; set; }
        public ShareCommand ShareCommand { get; set; }

        //Binding proprietes
        public string PageTitle { get; set; }
        private  bool isPaneOpen;
        public  bool IsPaneOpen
        {
            get { return isPaneOpen; }
            set
            {
                isPaneOpen = value;
                OnPropertyChanged();
            }
        }
        public StoryHeader Selected
        {
            get { return appContext.Selected; }
            set { appContext.Selected = value; }
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

        public HomeViewModel(IMvxNavigationService navigationService,
                             GardianAppContext appContext, 
                             NavCommand navCommand,
                             ShareCommand shareCommand)
        {

            this.appContext = appContext;
            appContext.Settings = new AppSettings("All News", string.Empty);
            appContext.SaveSettings(appContext.Settings);

            //Command
            GoToNewsDetailsCommand = new GoToNewsDetailsCommand(navigationService);
            NavMenuTriggerCommand = new MvxCommand(NavPanelTrigger);
            NavCommand = navCommand;
            ShareCommand = shareCommand;

            PageTitle = "All News";
            IsPaneOpen = true;
            NewsCollection = new ObservableCollection<StoryHeader>();
            
            ProgressRingIsActive = true;
            ProgressRingVisibility = true;
            Initialize();
        }
        public override async Task Initialize()
        {
           SetNewsCollectionAsync();
           appContext.CreateSecondaryTileAsync();
           await base.Initialize();
        }
        private void NavPanelTrigger()
        {
            IsPaneOpen = !IsPaneOpen;
        }
        private async void SetNewsCollectionAsync()
        {
            var result=await appContext.GetAllNewsAsync();
            if (result == null) return;

            NewsCollection = result;
            appContext.CreateSecondaryTileAsync();
            ProgressRingIsActive = false;
            ProgressRingVisibility = false;     
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
