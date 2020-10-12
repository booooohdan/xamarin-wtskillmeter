﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WTStatistics.Views;

namespace WTStatistics
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Helpers.License.Key());
            InitializeComponent();
            MainPage = new AppShell();
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