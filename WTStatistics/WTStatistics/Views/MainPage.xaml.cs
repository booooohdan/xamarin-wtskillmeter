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

        /// <summary>
        /// Get HTML string from webview and pass it to viewmodel
        /// </summary>
        private async void LoadingStarted(object sender, WebNavigatingEventArgs e)
        {
            for (int i = 0; i <= 30; i++)
            {
                var stringHTML = await theWebView.EvaluateJavaScriptAsync("document.body.innerHTML");

                if (!string.IsNullOrEmpty(stringHTML)
                    & stringHTML.Contains(searchBar.Text)
                    & stringHTML.Contains("AviationTable-TableData"))
                {
                    model.StartExtractData(stringHTML);
                    break;
                }
                else
                {
                    await Task.Delay(1000);
                    if (i == 30)
                        ErrorHandler(stringHTML);
                }
            }
        }

        /// <summary>
        /// Handle most common error
        /// </summary>
        /// <param name="stringHTML">HTML string from webview</param>
        private void ErrorHandler(string stringHTML)
        {
            IsBusy = false;
            if (stringHTML.Contains("Информации о пользователе недоступна"))
                Application.Current.MainPage.DisplayAlert("Incorrect nickname", "Nickname doesn\'t exist.\nPlease enter correct nickname", "OK");
            else
                Application.Current.MainPage.DisplayAlert("Timeout", "Something went wrong.\nPlease try again later.", "OK");
        }
    }
}