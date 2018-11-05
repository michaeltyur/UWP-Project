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
        private IShare _shareProvider;
        public ShareCommand(IShare shareProvider)
        {
            _shareProvider = shareProvider;
        }

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

            _shareProvider.Share(article.Title,article.Url);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
