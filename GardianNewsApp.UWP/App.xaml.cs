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
            var appContext = GardianAppContext.Instance;
            Mvx.IoCProvider.RegisterSingleton<ISettings>(() => new SettingsService());
            //SettingsService.LoadSettings();
        }
    }

    public abstract class UWPApplication : MvxApplication<MvxWindowsSetup<Core.App>,Core.App>
    {
        
    }
}
