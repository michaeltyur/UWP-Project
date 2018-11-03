using GardianNewsApp.Core.Interfaces;
using GardianNewsApp.Core.Models;
using MvvmCross;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardianNewsApp.Core.Commands
{
    public class ShareCommand : IMvxCommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute()
        {
            throw new NotImplementedException();
        }

        public bool CanExecute(object parameter)
        {
            
            return parameter!=null;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            ShareObject article = (ShareObject)parameter;

            var shareProvider = Mvx.IoCProvider.GetSingleton<IShare>();

            shareProvider.Share(article.Title,article.Url);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
