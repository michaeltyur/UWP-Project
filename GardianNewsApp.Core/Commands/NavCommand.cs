using GardianNewsApp.Core.Models;
using GardianNewsApp.Core.ViewModels;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardianNewsApp.Core.Commands
{
    public class NavCommand : IMvxCommand
    {
        public event EventHandler CanExecuteChanged;
        private IMvxNavigationService _navigationService;

        public NavCommand(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public bool CanExecute()
        {
            throw new NotImplementedException();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            var endpoint = (string)parameter;

            switch (endpoint)
            {
                case "All News":
                    _navigationService.Navigate<HomeViewModel>();
                    break;
                default:
                    _navigationService.Navigate<SectionViewModel, string>(endpoint);
                    break;
            }
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
