using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using WTStatistics.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WTStatistics.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel model;
        CancellationTokenSource source;

        public MainPage()
        {
            InitializeComponent();

            model = new MainPageViewModel();
            this.BindingContext = model;
            source = new CancellationTokenSource();
        }

        private async void LoadingStarted(object sender, WebNavigatingEventArgs e)
        {
            model.LionEarned = 1;
            model.IsBusy = true;
            await Task.Delay(15000, source.Token);
            CheckIfLoadingComplete();
        }

        private void CheckIfLoadingComplete()
        {
            model.IsBusy = false;
            model.LionEarned = 666;
        }

        private void LoadingFinished(object sender, WebNavigatedEventArgs e)
        {
            source.Cancel();
            model.LionEarned = 55;
            model.IsBusy = false;
            string s = model.URL;

        }
    }
}