﻿using GardianNewsApp.Core.Commands;
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
        //Commands
        private IMvxNavigationService _navigationService;
        public NavCommand NavCommand { get; set; }
        public ShareCommand ShareCommand { get; set; }

        private GardianAppContext appContext;

        //Selected Article
        private StoryHeader selected;
        public StoryHeader Selected
        {
            get { return selected; }
            set {
                  selected = value;
                  OnPropertyChanged();
                }
        }

        public string PageTitle { get; set; }
        private bool isPaneOpen;
        public bool IsPaneOpen
        {
            get { return isPaneOpen; }
            set { isPaneOpen = value; OnPropertyChanged(); }
        }

        #region Progress Ring
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
            set {
                   progressRingVisibility = value;
                   ItemBoxVisibility = !progressRingVisibility;
                   OnPropertyChanged(); }
        }

        public bool itemBoxVisibility;
        public bool ItemBoxVisibility
        {
            get { return itemBoxVisibility; }
            set { itemBoxVisibility = value; OnPropertyChanged(); }
        }
        #endregion

        public DetailsViewModel(IMvxNavigationService navigationService, 
                                GardianAppContext appContext, 
                                NavCommand navCommand,
                                ShareCommand shareCommand)
        {
            _navigationService = navigationService;

            this.appContext = appContext;

            //Commands
            NavMenuTriggerCommand = new MvxCommand(NavPanelTrigger);
            NavCommand = navCommand;
            ShareCommand = shareCommand;
            //Ring
            ProgressRingIsActive = true;
            ProgressRingVisibility = true;
            PageTitle = "Details";
         
        }
        public override async Task Initialize()
        {
            InitializeSelectedItem();
           
            await base.Initialize();
        }
        private async void InitializeSelectedItem()
        {
            var _parameter = appContext.Settings.IdSettings;
            if (!string.IsNullOrEmpty(_parameter))
            {
              Selected = await appContext.GetSingleItemAsync(_parameter);
                if (Selected == null)
                {
                    await _navigationService.Navigate<HomeViewModel>();
                    return;
                }
               ProgressRingIsActive = false;
               ProgressRingVisibility = false;
            }
        }

        public override void Prepare(string parameter)
        {
            appContext.Settings = new AppSettings(PageTitle, parameter);
            appContext.SaveSettings(appContext.Settings);
            InitializeSelectedItem();
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

