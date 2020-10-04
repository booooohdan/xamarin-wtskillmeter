using System;
using System.Collections.Generic;
using WTStatistics.Views;
using Xamarin.Forms;

namespace WTStatistics
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(FeedbackPage), typeof(FeedbackPage));
        }

    }
}
