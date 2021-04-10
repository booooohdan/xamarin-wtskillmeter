﻿using WTStatistics.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WTStatistics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackPage : ContentPage
    {
        public FeedbackPage()
        {
            InitializeComponent();
            BindingContext = new FeedbackViewModel();
        }
    }
}