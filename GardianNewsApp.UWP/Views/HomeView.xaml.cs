﻿using GardianNewsApp.Core.Models;
using MvvmCross.Platforms.Uap.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GardianNewsApp.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeView : MvxWindowsPage
    {
        public HomeView()
        {
            this.InitializeComponent();
        }

        private void NewsList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //var url = ((StoryHeader)((Control)e.OriginalSource).DataContext).WebUrl;
            //GardianAppContext.Instance.GoToNewsDetails(url);
        }

        private void NewsList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
