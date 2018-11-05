using GardianNewsApp.Core.Models;
using GardianNewsApp.Core.ViewModels;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GardianNewsApp.Core.Commands
{
    public class GoToNewsDetailsCommand : IMvxCommand
    {
        private IMvxNavigationService _navigationService;

        public GoToNewsDetailsCommand(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public event EventHandler CanExecuteChanged;

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
            string idItem = (string)parameter;

            _navigationService.Navigate<DetailsViewModel,string>(idItem);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
