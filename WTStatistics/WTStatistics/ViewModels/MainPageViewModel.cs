using System;
using System.Collections.ObjectModel;
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
        public ObservableCollection<ChartDataModel> DoughnutSeriesData { get; set; }
        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            SearchButtonPressed = new Command<string>(HandleSearchPressed);
            player = new Player();
            DoughnutSeriesData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Not available", 0)
            };
        }
        #endregion

        public bool IsBusy
        {
            get => busy;
            set
            {
                busy = value;
                OnPropertyChanged();
            }
        }

        public string URL
        {
            get => url;
            set
            {
                url = value;
                OnPropertyChanged();
            }
        }

        public string SearchBarText
        {
            get => searchBatText;
            set
            {
                searchBatText = value;
                OnPropertyChanged();
            }
        }


        public string LionEarned
        {
            get => player.LionEarned;
            set
            {
                player.LionEarned = value;
                OnPropertyChanged();
            }
        }

        public string BattleFinished
        {
            get => player.BattleFinished;
            set
            {
                player.BattleFinished = value;
                OnPropertyChanged();
            }
        }

        public string TotalTimeSpended
        {
            get => player.TotalTimeSpended;
            set
            {
                player.TotalTimeSpended = value;
                OnPropertyChanged();
            }
        }

        public string SignUpDate
        {
            get => player.SignUpDate;
            set
            {
                player.SignUpDate = value;
                OnPropertyChanged();
            }
        }

        public string Squadron
        {
            get => player.Squadron;
            set
            {
                player.Squadron = value;
                OnPropertyChanged();
            }
        }     
        
        public int WinRateAB
        {
            get => player.WinRateAB;
            set
            {
                player.WinRateAB = value;
                OnPropertyChanged();
            }
        }

        public int WinRateRB
        {
            get => player.WinRateRB;
            set
            {
                player.WinRateRB = value;
                OnPropertyChanged();
            }
        }

        public int WinRateSB
        {
            get => player.WinRateSB;
            set
            {
                player.WinRateSB = value;
                OnPropertyChanged();
            }
        }

        public double KD_AAB
        {
            get => player.KD_AAB;
            set
            {
                player.KD_AAB = value;
                OnPropertyChanged();
            }
        }

        public double KD_ARB
        {
            get => player.KD_ARB;
            set
            {
                player.KD_ARB = value;
                OnPropertyChanged();
            }
        }

        public double KD_ASB
        {
            get => player.KD_ASB;
            set
            {
                player.KD_ASB = value;
                OnPropertyChanged();
            }
        }

        public double KD_TAB
        {
            get => player.KD_TAB;
            set
            {
                player.KD_TAB = value;
                OnPropertyChanged();
            }
        }

        public double KD_TRB
        {
            get => player.KD_TRB;
            set
            {
                player.KD_TRB = value;
                OnPropertyChanged();
            }
        }

        public double KD_TSB
        {
            get => player.KD_TSB;
            set
            {
                player.KD_TSB = value;
                OnPropertyChanged();
            }
        }

        public double KD_SAB
        {
            get => player.KD_SAB;
            set
            {
                player.KD_SAB = value;
                OnPropertyChanged();
            }
        }

        public double KD_SRB
        {
            get => player.KD_SRB;
            set
            {
                player.KD_SRB = value;
                OnPropertyChanged();
            }
        }


        private double Skill
        {
            set
            {
                player.TotalSkillBackground = value;

                if (value >= 0 & value <= 0.6)
                {
                    SkillGradient = "grad_red.png";
                    SkillDescription = "Bad player";
                }
                if (value > 0.6 & value <= 0.9)
                {
                    SkillGradient = "grad_yellow.png";
                    SkillDescription = "Average player";
                }
                if (value > 0.9 & value <= 1.1)
                {
                    SkillGradient = "grad_green.png";
                    SkillDescription = "Good player";
                }
                if (value > 1.1 & value <= 1.5)
                {
                    SkillGradient = "grad_blue.png";
                    SkillDescription = "Excellent player";
                }
                if (value > 1.5)
                {
                    SkillGradient = "grad_violet.png";
                    SkillDescription = "Outstanding player";
                }
                OnPropertyChanged();
            }
        }

        public string SkillGradient
        {
            get => player.SkillGradient;
            set
            {
                player.SkillGradient = value;
                OnPropertyChanged();
            }
        }


        public string SkillDescription
        {
            get => player.SkillDescription;
            set
            {
                player.SkillDescription = value;
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

        private string ConvertToKM(string convertedValue)
        {
            double num = Convert.ToDouble(convertedValue);
            string converted=string.Empty;
            if (num > 1000000)
            {
                converted = Math.Round(num / 1000000, 1)+" M";
            }else
            if (num > 1000)
            {
                converted = Math.Round(num / 1000, 1) + " K";
            }
            else
            {
                converted = num.ToString();
            }
            return converted;
        }

        /// <summary>
        /// Get data drom HTML string and set property values
        /// </summary>
        /// <param name="htmlString">HTML string from webview</param>
        public void StartExtractData(string htmlString)
        {
            IsBusy = false;
            DataFromHtmlString data = new DataFromHtmlString(htmlString);

            LionEarned = ConvertToKM(data.PlayerInfo().LionEarned);
            BattleFinished = ConvertToKM(data.PlayerInfo().BattleFinished);
            TotalTimeSpended = data.PlayerInfo().TotalTimeSpended+" D";
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

            DoughnutSeriesData.Clear();
            DoughnutSeriesData.Add(new ChartDataModel("Air AB", data.PlayerInfo().CountAAB));
            DoughnutSeriesData.Add(new ChartDataModel("Air RB", data.PlayerInfo().CountARB));
            DoughnutSeriesData.Add(new ChartDataModel("Air SB", data.PlayerInfo().CountASB));
            DoughnutSeriesData.Add(new ChartDataModel("Tank AB", data.PlayerInfo().CountTAB));
            DoughnutSeriesData.Add(new ChartDataModel("Tank RB", data.PlayerInfo().CountTRB));
            DoughnutSeriesData.Add(new ChartDataModel("Tank SB", data.PlayerInfo().CountTSB));
            DoughnutSeriesData.Add(new ChartDataModel("Fleet AB", data.PlayerInfo().CountSAB));
            DoughnutSeriesData.Add(new ChartDataModel("Fleet RB", data.PlayerInfo().CountSRB));

        }
    }
}