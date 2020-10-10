using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
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
        public ObservableCollection<ChartDataModel> DoughnutSeriesData { get; set; }
        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            SearchButtonPressed = new Command<string>(HandleSearchPressed);
            player = new Player();

            DoughnutSeriesData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Labour", 10),
                new ChartDataModel("Legal", 8),
                new ChartDataModel("Production", 7),
                new ChartDataModel("License", 5),
                new ChartDataModel("Facilities", 10),
                new ChartDataModel("Taxes", 6),
                new ChartDataModel("Insurance", 18)
           };
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
            get { return  player.LionEarned; }
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


        public int WinRateAB
        {
            get { return player.WinRateAB; }
            set
            {
                player.WinRateAB = value;
                OnPropertyChanged();
            }
        }

        public int WinRateRB
        {
            get { return player.WinRateRB; }
            set
            {
                player.WinRateRB = value;
                OnPropertyChanged();
            }
        }

        public int WinRateSB
        {
            get { return player.WinRateSB; }
            set
            {
                player.WinRateSB = value;
                OnPropertyChanged();
            }
        }

        public double KD_AAB
        {
            get { return player.KD_AAB; }
            set
            {
                player.KD_AAB = value;
                OnPropertyChanged();
            }
        }

        public double KD_ARB
        {
            get { return player.KD_ARB; }
            set
            {
                player.KD_ARB = value;
                OnPropertyChanged();
            }
        }

        public double KD_ASB
        {
            get { return player.KD_ASB; }
            set
            {
                player.KD_ASB = value;
                OnPropertyChanged();
            }
        }

        public double KD_TAB
        {
            get { return player.KD_TAB; }
            set
            {
                player.KD_TAB = value;
                OnPropertyChanged();
            }
        }

        public double KD_TRB
        {
            get { return player.KD_TRB; }
            set
            {
                player.KD_TRB = value;
                OnPropertyChanged();
            }
        }

        public double KD_TSB
        {
            get { return player.KD_TSB; }
            set
            {
                player.KD_TSB = value;
                OnPropertyChanged();
            }
        }

        public double KD_SAB
        {
            get { return player.KD_SAB; }
            set
            {
                player.KD_SAB = value;
                OnPropertyChanged();
            }
        }

        public double KD_SRB
        {
            get { return player.KD_SRB; }
            set
            {
                player.KD_SRB = value;
                OnPropertyChanged();
            }
        }

        private int selectedIndex;
        private string _selectedItemName;
        private double _selectedItemsPercentage;

        public string SelectedItemName
        {
            get { return _selectedItemName; }
            set
            {
                _selectedItemName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItemName"));
            }
        }

        public double SelectedItemsPercentage
        {
            get { return _selectedItemsPercentage; }
            set
            {
                _selectedItemsPercentage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItemsPercentage"));
            }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                if (selectedIndex == -1) return;

                SelectedItemName = DoughnutSeriesData[selectedIndex].Name;

                var sum = DoughnutSeriesData.Sum(item => item.Value);
                var selectedValue = DoughnutSeriesData[selectedIndex].Value;

                SelectedItemsPercentage = (selectedValue / sum) * 100;
                SelectedItemsPercentage = Math.Floor(SelectedItemsPercentage * 100) / 100;
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

            WinRateAB = data.PlayerInfo().WinRateAB;
            WinRateRB = data.PlayerInfo().WinRateRB;
            WinRateSB = data.PlayerInfo().WinRateSB;

            KD_AAB = data.PlayerInfo().KD_AAB;
            KD_ARB = data.PlayerInfo().KD_ARB;
            KD_ASB = data.PlayerInfo().KD_ASB;
            KD_TAB = data.PlayerInfo().KD_TAB;
            KD_TRB = data.PlayerInfo().KD_TRB;
            KD_TSB = data.PlayerInfo().KD_TSB;
            KD_SAB = data.PlayerInfo().KD_SAB;
            KD_SRB = data.PlayerInfo().KD_SRB;
        }
    }
}