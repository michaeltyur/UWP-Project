using MvvmCross.Platforms.Uap.Core;
using MvvmCross.Platforms.Uap.Views;
using GardianNewsApp.UWP.Settings;
using MvvmCross;
using GardianNewsApp.Core.Interfaces;
using GardianNewsApp.UWP.Share;
using Windows.UI.StartScreen;
using System;
using GardianNewsApp.UWP.Tiles;

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
            Mvx.IoCProvider.RegisterSingleton<ITileProvider>(new TilesService());

            base.InitializeFirstChance();
                
        }
    }
}
