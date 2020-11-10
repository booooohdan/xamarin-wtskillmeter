using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WTStatistics.Models;
using WTStatistics.ViewModels;
using WTStatistics.Views;
using Xamarin.Essentials;
using Plugin.StoreReview;

namespace WTStatistics.Views
{
    public partial class FeedbackPage : ContentPage
    {
        FeedbackViewModel model;
        public FeedbackPage()
        {
            InitializeComponent();
            model = new FeedbackViewModel();
            BindingContext = model;
        }
        
        // RatingBar value change handler
        private void SfRating_ValueChanged(object sender, Syncfusion.SfRating.XForms.ValueEventArgs e)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    CrossStoreReview.Current.RequestReview();
                    break;
                case Device.iOS:
                    //Launcher.OpenAsync(new Uri("https://play.google.com/store/apps/details?id=com.wave.skillmeter"));
                    /*ar url = $"itms-apps://itunes.apple.com/app/id{appId}?action=write-review";
                    try
                    {
                        UIApplication.SharedApplication.OpenUrl(new NSUrl(url));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Unable to launch app store: " + ex.Message);
                    }*/
                    break;
            }
        }
    }
}