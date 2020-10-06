using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WTStatistics.Models;
using WTStatistics.Views;
using Xamarin.Forms;

namespace WTStatistics.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Private property
        string searchBatText;
        bool busy;
        string url;
        public Player Player;
        #endregion

        #region Property Change event and commands
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SearchButtonPressed { private set; get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Constructor
        public MainPageViewModel()
        {
            SearchButtonPressed = new Command<string>(HandleSearchPressed);
            Player = new Player();
        }
        #endregion

        #region SearchBar handler
        private void HandleSearchPressed(string searchText)
        {
            SearchBarText = searchText;
            IsBusy = true;
            URL = "https://warthunder.ru/ru/community/userinfo/?nick=" + searchText;
        }

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public string URL
        {
            get { return url; }
            set
            {
                url = value;
                OnPropertyChanged("URL");               
            }
        }

        public string SearchBarText
        {
            get { return searchBatText; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                searchBatText = value;
                }
                //Load statistics

            }
        }
        #endregion

        public int LionEarned
        {
            get { return Player.LionEarned; }
            set
            {
                Player.LionEarned = value;
                OnPropertyChanged("LionEarned");
            }
        }


    }
}