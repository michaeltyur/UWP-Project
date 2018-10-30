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
                .AsInterfaces()
                .RegisterAsLazySingleton();


            //Mvx.IoCProvider.RegisterSingleton(() => new GardianAppContext());

            var settings = GardianAppContext.Instance.Settings;
            if (settings != null)
            {
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



            //RegisterAppStart<MainPageViewModel>();
        }
    }
}
