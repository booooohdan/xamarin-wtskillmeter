using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace WTStatistics.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Private property
        string searchBatText;
        int lionEarned;
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
        }
        #endregion

        #region SearchBar handler
        private void HandleSearchPressed(string searchText)
        {
            SearchBarText = searchText;
        }

        public string SearchBarText
        {
            get { return searchBatText; }
            set
            {
                searchBatText = value;
                //Load statistics
            }
        }
        #endregion

        public int LionEarned
        {
            get { return lionEarned; }
            set
            {
                lionEarned = value;
                OnPropertyChanged("LionEarned");
            }
        }


    }
}