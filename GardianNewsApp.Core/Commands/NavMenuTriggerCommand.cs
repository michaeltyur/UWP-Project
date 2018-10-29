using GardianNewsApp.Core.Models;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardianNewsApp.Core.Commands
{
    public class NavMenuTriggerCommand : IMvxCommand
    {
        public event EventHandler CanExecuteChanged;
        private bool _isPaneOpen;
        public NavMenuTriggerCommand(ref bool isPaneOpen)
        {
            _isPaneOpen = isPaneOpen;
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
            _isPaneOpen = !_isPaneOpen;
        }

        public void Execute(object parameter)
        {
            _isPaneOpen = !_isPaneOpen;
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
