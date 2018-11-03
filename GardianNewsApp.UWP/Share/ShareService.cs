using GardianNewsApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace GardianNewsApp.UWP.Share
{
    public class ShareService:IShare
    {
        private string _articleTitle;
        private string _url;

        public ShareService()
        {

        }


        public void Share(string articleTitle, string url)
        {
            _articleTitle = articleTitle;
            _url = url;
            DataTransferManager.ShowShareUI();
            DataTransferManager.GetForCurrentView().DataRequested += MainPage_DataRequested;
        }
        void MainPage_DataRequested(DataTransferManager sender,DataRequestedEventArgs args)
        {
            if (!string.IsNullOrEmpty(_url))
            {
             
                args.Request.Data.SetText($"[Shared Article] {_articleTitle}");
                args.Request.Data.SetWebLink(new Uri(_url));

                args.Request.Data.Properties.Title = Windows.ApplicationModel.Package.Current.DisplayName;
            }
            else
            {
                args.Request.FailWithDisplayText("Nothing to share");
            }
        }
    }
}
