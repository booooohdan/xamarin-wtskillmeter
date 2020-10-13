using System;
using System.Collections.Generic;
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
        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            SearchButtonPressed = new Command<string>(HandleSearchPressed);
            player = new Player();
            HeaderColor = "#574d55";
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

        public double Skill
        {
            get { return player.TotalSkillBackground; }
            set
            {
                player.TotalSkillBackground = value;

                if (value >= 0 & value <= 0.6)
                {
                    HeaderColor = "#e31670";
                }
                if (value > 0.6 & value <= 0.9)
                {
                    HeaderColor = "#f19411";
                }
                if (value > 0.9 & value <= 1.4)
                {
                    HeaderColor = "#16a58c";
                }
                if (value > 1.4 & value <= 2.0)
                {
                    HeaderColor = "#28a3da";
                }
                if (value > 2.0)
                {
                    HeaderColor = "#a11887";
                }
                OnPropertyChanged();
            }
        }

        public string HeaderColor
        {
            get { return player.HeaderColor; }
            set
            {
                player.HeaderColor = value;
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

            Skill = data.PlayerInfo().TotalSkillBackground;
        }
    }
}