using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WTStatistics.Views;
using System.Threading;
using System.Globalization;

namespace WTStatistics
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Helpers.License.Key());
            InitializeComponent();
            MainPage = new MainTabbedPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
