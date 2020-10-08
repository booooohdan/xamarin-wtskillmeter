using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WTStatistics.Helpers;
using WTStatistics.Models;
using Xamarin.Forms;

namespace WTStatistics.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Propertys, events and commands

        string searchBatText;
        bool busy;
        string url;
        Player player;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SearchButtonPressed { get; }
        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            SearchButtonPressed = new Command<string>(HandleSearchPressed);
            player = new Player();
        }
        #endregion

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
            }
        }

        public string URL
        {
            get { return url; }
            set
            {
                url = value;
                OnPropertyChanged();               
            }
        }

        public string SearchBarText
        {
            get { return searchBatText; }
            set
            {
                searchBatText = value;
                OnPropertyChanged();
            }
        }


        public int LionEarned
        {
            get { return player.LionEarned; }
            set
            {
                player.LionEarned = value;
                OnPropertyChanged();
            }
        }

        public int BattleFinished
        {
            get { return player.BattleFinished; }
            set
            {
                player.BattleFinished = value;
                OnPropertyChanged();
            }
        }

        public double TotalTimeSpended
        {
            get { return player.TotalTimeSpended; }
            set
            {
                player.TotalTimeSpended = value;
                OnPropertyChanged();
            }
        }

        public string SignUpDate
        {
            get { return player.SignUpDate; }
            set
            {
                player.SignUpDate = value;
                OnPropertyChanged();
            }
        }

        public string Squadron
        {
            get { return player.Squadron; }
            set
            {
                player.Squadron = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// OnPropertyChanged (syntactic sugar)
        /// </summary>
        /// <param name="propertyName">Name of binding property</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// SearchBar command handler
        /// </summary>
        /// <param name="searchText">Nickname</param>
        private void HandleSearchPressed(string searchText)
        {
            IsBusy = true;
            SearchBarText = searchText;
            URL = "https://warthunder.ru/ru/community/userinfo/?nick=" + searchText;
        }

        /// <summary>
        /// Get data drom HTML string and set property values
        /// </summary>
        /// <param name="htmlString">HTML string from webview</param>
        public void StartExtractData(string htmlString)
        {
            IsBusy = false;
            DataFromHtmlString data = new DataFromHtmlString(htmlString);

            LionEarned = data.PlayerInfo().LionEarned;
            BattleFinished = data.PlayerInfo().BattleFinished;
            TotalTimeSpended = data.PlayerInfo().TotalTimeSpended;
            SignUpDate = data.PlayerInfo().SignUpDate;
            Squadron = data.PlayerInfo().Squadron;
        }
    }
}