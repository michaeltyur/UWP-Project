using GardianNewsApp.Core.Commands;
using GardianNewsApp.Core.Interfaces;
using GardianNewsApp.Core.Models;
using GardianNewsApp.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GardianNewsApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {

            CreatableTypes()
                .EndingWith("Service")
                .AsTypes()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<GardianAppContext, GardianAppContext>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<NavCommand, NavCommand>(); 
                Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ShareCommand, ShareCommand>();
            var settings = Mvx.IoCProvider.GetSingleton<ISettings>().LoadSettings().Result;

            if (settings!=null)
            {
               

                Mvx.IoCProvider.GetSingleton<GardianAppContext>().Settings = settings;
                switch (settings.PageSettings)
                {
                    case "Football":
                    case "Animals":
                    case "Art and Design":
                    case "Books":
                    case "Australia-News":
                    case "Culture":
                        RegisterAppStart<SectionViewModel, string>();

                        break;
                    case "Details":
                        RegisterAppStart<DetailsViewModel, string>();
                        break;
                    default:
                        RegisterAppStart<HomeViewModel>();
                        break;

                }
            } 
            else RegisterAppStart<HomeViewModel>();

        }
    }
}
