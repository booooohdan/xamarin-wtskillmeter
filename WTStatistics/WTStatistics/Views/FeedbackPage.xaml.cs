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
            CrossStoreReview.Current.RequestReview();
        }
    }
}