﻿using GardianNewsApp.Core.Interfaces;
using GardianNewsApp.UWP.Settings;
using MvvmCross;
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
    public sealed partial class DetailsView : MvxWindowsPage
    {
        public DetailsView()
        {
            this.InitializeComponent();
        }
        private void MvxWindowsPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var size = ((Frame)Window.Current.Content).ActualWidth;
            if (size < 645)
            {
                SplitView.IsPaneOpen = false;
            }
            else SplitView.IsPaneOpen = true; ;

        }
    }
}
