using GardianNewsApp.Core.ViewModels;
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

        public GoToNewsDetailsCommand(IMvxNavigationService mvxNavigation)
        {
            _navigationService = mvxNavigation;
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
            string url = (string)parameter;
             _navigationService.Navigate<DetailsViewModel, string>(url);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
