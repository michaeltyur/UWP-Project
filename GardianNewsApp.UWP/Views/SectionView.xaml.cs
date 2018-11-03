using MvvmCross.Platforms.Uap.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GardianNewsApp.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SectionView : MvxWindowsPage
    {
        public SectionView()
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
