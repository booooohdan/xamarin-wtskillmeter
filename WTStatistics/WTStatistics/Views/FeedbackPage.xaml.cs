using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WTStatistics.Models;
using WTStatistics.Views;
using Xamarin.Essentials;

namespace WTStatistics.Views
{
    public partial class FeedbackPage : ContentPage
    {

        public FeedbackPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void SfRating_ValueChanged(object sender, Syncfusion.SfRating.XForms.ValueEventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://www.reddit.com/r/wtversus/"));
        }
    }
}