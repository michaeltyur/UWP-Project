﻿using GardianNewsApp.Core.Models;
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
        IMvxNavigationService _navigationService;
        public GoToNewsDetailsCommand(IMvxNavigationService navigationService)
        {
                
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
            //GardianAppContext.Instance.GoToNewsDetails(url);
            _navigationService.Navigate<DetailsViewModel, string>(url);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
