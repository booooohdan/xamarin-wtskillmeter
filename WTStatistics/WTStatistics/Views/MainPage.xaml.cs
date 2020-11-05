using System;
using System.Threading.Tasks;
using WTStatistics.ViewModels;
using Xamarin.Forms;

namespace WTStatistics.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel model;

        public MainPage()
        {
            InitializeComponent();
            model = new MainPageViewModel();
            BindingContext = model;
        }
        
        // Get HTML string from webview and pass it to viewmodel
        private async void LoadingStarted(object sender, WebNavigatingEventArgs e)
        {
            try
            {
                for (int i = 0; i <= 30; i++)
                {
                    string stringHTML = await theWebView.EvaluateJavaScriptAsync("document.body.innerHTML");

                    if (!string.IsNullOrEmpty(stringHTML)
                        && stringHTML.Contains(searchBar.Text)
                        && stringHTML.Contains("AllStatTable-TableData"))
                    {
                        model.StartExtractData(stringHTML);
                        break;
                    }
                    else
                    {
                        await Task.Delay(1000);
                        if (i == 30)
                        {
                            ErrorHandler(stringHTML);
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                ErrorHandler("error message");
            }
        }
        
        // Handle most common error
        private void ErrorHandler(string stringHTML)
        {
            ActivityIndicator.IsRunning = false;

            if (stringHTML.Contains("Информации о пользователе недоступна"))
                Application.Current.MainPage.DisplayAlert("Incorrect nickname", "Nickname doesn\'t exist.\nPlease enter correct nickname", "OK");
            else
                Application.Current.MainPage.DisplayAlert("Timeout", "Something went wrong.\nPlease try again later.", "OK");
        }
    }
}