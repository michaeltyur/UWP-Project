using System;
using MvvmCross.Platforms.Uap.Core;
using MvvmCross.Platforms.Uap.Views;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GardianNewsApp.UWP.Settings;
using MvvmCross;
using GardianNewsApp.Core.Models;
using GardianNewsApp.Core.Interfaces;
using Windows.UI.Popups;
using GardianNewsApp.UWP.Share;

namespace GardianNewsApp.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
     sealed partial class App : UWPApplication
    {
        public App()
        {
            InitializeComponent();
           
        }

    }

    public abstract class UWPApplication : MvxApplication<CustomSetup, Core.App>
    {
        
    }
    public class CustomSetup: MvxWindowsSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            Mvx.IoCProvider.RegisterSingleton<ISettings>(new SettingsService());
            Mvx.IoCProvider.RegisterSingleton<IShare>(new ShareService());
           

            base.InitializeFirstChance();
                
        }
    }
}
