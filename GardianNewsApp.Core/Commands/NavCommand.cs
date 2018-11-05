using GardianNewsApp.Core.Models;
using GardianNewsApp.Core.ViewModels;
using MvvmCross;
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
        private GardianAppContext _appContext;

        public NavCommand(IMvxNavigationService navigationService, GardianAppContext appContext)
        {
            _navigationService = navigationService;
            _appContext = appContext;
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
            var section = (string)parameter;

            switch (section)
            {
                case "All News":
                    _navigationService.Navigate<HomeViewModel>();
                    break;
                default:
                    {
                        _appContext.Settings = new AppSettings(section, "");
                        _navigationService.Navigate<SectionViewModel, string>(section);
                    }
                    break;
            }
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
