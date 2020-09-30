using System;
using System.Collections.Generic;
using WTStatistics.ViewModels;
using WTStatistics.Views;
using Xamarin.Forms;

namespace WTStatistics
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
