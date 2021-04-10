using Plugin.StoreReview;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WTStatistics.Resx;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WTStatistics.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand RateCommand { get; set; }
        public ICommand ShareCommand { get; set; }
        public ICommand PrivacyCommand { get; set; }
        public ICommand HintsCommand { get; set; }
        private string currentAppVersion;
        private string dbDateUpdate;

        public string CurrentAppVersion
        {
            get => currentAppVersion;
            set
            {
                currentAppVersion = value;
                OnPropertyChanged();
            }
        }
        public string DbDateUpdate
        {
            get => dbDateUpdate;
            set
            {
                dbDateUpdate = value;
                OnPropertyChanged();
            }
        }

        public AboutViewModel()
        {
            RateCommand = new Command(RateHandler);
            ShareCommand = new Command(ShareHandler);
            PrivacyCommand = new Command(PrivacyHandler);
            HintsCommand = new Command(HintsHandler);

            CurrentAppVersion = AppResources.Version + AppInfo.VersionString;
        }

        private void RateHandler(object obj)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    CrossStoreReview.Current.OpenStoreReviewPage("com.wave.skillmeter");
                    break;
                case Device.iOS:
                    CrossStoreReview.Current.OpenStoreReviewPage("1542964380");
                    break;
            }
        }

        private async void ShareHandler(object obj)
        {
            string appLink = string.Empty;

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    appLink = "https://play.google.com/store/apps/details?id=com.wave.skillmeter";
                    break;
                case Device.iOS:
                    appLink = "https://apps.apple.com/ph/app/skill-meter/id1542964380";
                    break;
            }

            await Share.RequestAsync(new ShareTextRequest
            {
                Title = AppResources.ShareWithFriends,
                Text = AppResources.CheckThisCoolApp,
                Uri = appLink,

            });
        }

        private void PrivacyHandler(object obj)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    Launcher.OpenAsync(new Uri("https://wt-skill-meter.flycricket.io/privacy.html"));
                    break;
                case Device.iOS:
                    Launcher.OpenAsync(new Uri("https://wt-skill-meter.flycricket.io/privacy.html"));
                    break;
            }
        }

        private void HintsHandler(object obj)
        {
            //TODO: Implement hints logic
        }
    }
}
