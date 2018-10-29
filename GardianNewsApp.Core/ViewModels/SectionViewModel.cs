using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardianNewsApp.Core.ViewModels
{
    public class SectionViewModel : MvxViewModel<string>
    {
        public string PageTitle { get; set; }

        public SectionViewModel()
        {
                
        }
        public override void Prepare(string parameter)
        {
            PageTitle = parameter;
            throw new NotImplementedException();
        }
    }
}
