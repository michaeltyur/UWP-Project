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

            RegisterAppStart<HomeViewModel>();
            
            //RegisterAppStart<MainPageViewModel>();
        }
    }
}
