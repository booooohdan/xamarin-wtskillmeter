using MarcTron.Plugin;
using Plugin.StoreReview;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WTStatistics.Helpers;
using WTStatistics.Models;
using WTStatistics.Resx;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WTStatistics.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Init propertys and commands
        Player player;
        string searchBatText;
        string url;
        int adsCount = 0;
        int adsNum = 4;
        int start_count = Preferences.Get("start_count", 0);

        public ICommand SearchButtonPressed { get; }
        public ICommand GamepadCommand { get; }
        public ObservableCollection<ChartDataModel> DoughnutSeriesData { get; set; }
        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            SearchButtonPressed = new Command<string>(HandleSearchPressed);
            GamepadCommand = new Command<string>(HandleGamepadPressed);
            player = new Player();
            DoughnutSeriesData = DoughnutInit.Init();


            start_count++;
            Preferences.Set("start_count", start_count);
            ShowReview(start_count);
        }
        #endregion

        #region Properties
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
        
        public string Avatar
        {
            get => player.SkillGradient;
            set
            {
                player.SkillGradient = value;
                OnPropertyChanged();
            }
        }

        public string HashTag
        {
            get => player.SkillDescription;
            set
            {
                player.SkillDescription = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods

        //Build searched url
        private void HandleSearchPressed(string searchText)
        {
            SearchBarText = searchText;
            URL = "https://warthunder.ru/ru/community/userinfo/?nick=" + searchText;
        }

        //Gamepad hint
        private void HandleGamepadPressed(string obj)
        {
            Application.Current.MainPage.DisplayAlert(AppResources.ConsoleHintLabel,
                "If you have PS account, add @psn to end of your nickname\nIf you have Xbox account, add @live to end of your nickname\nFor example \nPlayer1@psn\nPlayer1@live", "OK");
        }

        //Review request
        private void ShowReview(int start_count)
        {
            if (start_count == 5 || start_count == 15)
            {
                CrossStoreReview.Current.RequestReview();
            }
        }

        //Set value from data class to ViewModel properties
        public void StartExtractData(string htmlString)
        {
            #region Intersitial Ad

            adsCount++;
            CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-8211072909515345/8885441043");
            if ((adsCount % adsNum) ==0)
            {
                CrossMTAdmob.Current.ShowInterstitial();
            }
            #endregion

            DataFromHtmlString data = new DataFromHtmlString(htmlString);

            Avatar = data.Info().Avatar;
            HashTag = data.Info().HashTag;
            SkillGradient = data.Info().SkillGradient;
            SkillDescription = data.Info().SkillDescription;

            SignUpDate = data.Info().SignUpDate;
            Squadron = data.Info().Squadron;
            BattleFinished = data.Info().BattleFinished;
            TotalTimeSpended = data.Info().TotalTimeSpended;
            LionEarned = data.Info().LionEarned;

            WinRateAB = data.Info().WinRateAB;
            WinRateRB = data.Info().WinRateRB;
            WinRateSB = data.Info().WinRateSB;

            KD_AAB = data.Info().KD_AAB;
            KD_ARB = data.Info().KD_ARB;
            KD_ASB = data.Info().KD_ASB;
            KD_TAB = data.Info().KD_TAB;
            KD_TRB = data.Info().KD_TRB;
            KD_TSB = data.Info().KD_TSB;
            KD_SAB = data.Info().KD_SAB;
            KD_SRB = data.Info().KD_SRB;

            DoughnutSeriesData.Clear();
            DoughnutSeriesData.Add(new ChartDataModel("Air AB", data.Info().CountAAB));
            DoughnutSeriesData.Add(new ChartDataModel("Air RB", data.Info().CountARB));
            DoughnutSeriesData.Add(new ChartDataModel("Air SB", data.Info().CountASB));
            DoughnutSeriesData.Add(new ChartDataModel("Tank AB", data.Info().CountTAB));
            DoughnutSeriesData.Add(new ChartDataModel("Tank RB", data.Info().CountTRB));
            DoughnutSeriesData.Add(new ChartDataModel("Tank SB", data.Info().CountTSB));
            DoughnutSeriesData.Add(new ChartDataModel("Fleet AB", data.Info().CountSAB));
            DoughnutSeriesData.Add(new ChartDataModel("Fleet RB", data.Info().CountSRB));
        }
        #endregion
    }
}