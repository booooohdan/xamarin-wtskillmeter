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
        int adsNum = 3;
        int start_count = Preferences.Get("start_count", 0);

        public ICommand SearchButtonPressed { get; }
        public ICommand GamepadCommand { get; }
        public ObservableCollection<ChartDataModel> DoughnutSeriesData { get; set; }
        public ObservableCollection<BarChartDataModel> BarChartData { get; set; }
        public ObservableCollection<BarChartDataModel> BarChartDataTotal { get; set; }

        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            SearchButtonPressed = new Command<string>(HandleSearchPressed);
            GamepadCommand = new Command<string>(HandleGamepadPressed);
            player = new Player();
            DoughnutSeriesData = DoughnutInit.Init();
            BarChartData = ChartBarInit.Init();
            BarChartDataTotal = ChartBarTotalInit.Init();

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

        public double FavoriteVehicle1
        {
            get => player.FavoriteVehicle1;
            set
            {
                player.FavoriteVehicle1 = value;
                OnPropertyChanged();
            }
        }

        public double FavoriteVehicle2
        {
            get => player.FavoriteVehicle2;
            set
            {
                player.FavoriteVehicle2 = value;
                OnPropertyChanged();
            }
        }

        public double FavoriteVehicle3
        {
            get => player.FavoriteVehicle3;
            set
            {
                player.FavoriteVehicle3 = value;
                OnPropertyChanged();
            }
        }

        public double FavoriteVehicle4
        {
            get => player.FavoriteVehicle4;
            set
            {
                player.FavoriteVehicle4 = value;
                OnPropertyChanged();
            }
        }

        public double FavoriteVehicle5
        {
            get => player.FavoriteVehicle5;
            set
            {
                player.FavoriteVehicle5 = value;
                OnPropertyChanged();
            }
        }

        public string FavoriteVehicleName1
        {
            get => player.FavoriteVehicleName1;
            set
            {
                player.FavoriteVehicleName1 = value;
                OnPropertyChanged();
            }
        }

        public string FavoriteVehicleName2
        {
            get => player.FavoriteVehicleName2;
            set
            {
                player.FavoriteVehicleName2 = value;
                OnPropertyChanged();
            }
        }

        public string FavoriteVehicleName3
        {
            get => player.FavoriteVehicleName3;
            set
            {
                player.FavoriteVehicleName3 = value;
                OnPropertyChanged();
            }
        }

        public string FavoriteVehicleName4
        {
            get => player.FavoriteVehicleName4;
            set
            {
                player.FavoriteVehicleName4 = value;
                OnPropertyChanged();
            }
        }

        public string FavoriteVehicleName5
        {
            get => player.FavoriteVehicleName5;
            set
            {
                player.FavoriteVehicleName5 = value;
                OnPropertyChanged();
            }
        }

        public string FavoriteVehicleIcon1
        {
            get => player.FavoriteVehicleIcon1;
            set
            {
                player.FavoriteVehicleIcon1 = value;
                OnPropertyChanged();
            }
        }

        public string FavoriteVehicleIcon2
        {
            get => player.FavoriteVehicleIcon2;
            set
            {
                player.FavoriteVehicleIcon2 = value;
                OnPropertyChanged();
            }
        }

        public string FavoriteVehicleIcon3
        {
            get => player.FavoriteVehicleIcon3;
            set
            {
                player.FavoriteVehicleIcon3 = value;
                OnPropertyChanged();
            }
        }

        public string FavoriteVehicleIcon4
        {
            get => player.FavoriteVehicleIcon4;
            set
            {
                player.FavoriteVehicleIcon4 = value;
                OnPropertyChanged();
            }
        }

        public string FavoriteVehicleIcon5
        {
            get => player.FavoriteVehicleIcon5;
            set
            {
                player.FavoriteVehicleIcon5 = value;
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
                AppResources.ConsoleHint, "OK");
        }

        //Review request
        private void ShowReview(int start_count)
        {
            if (start_count == 5 || start_count == 15)
            {
                CrossStoreReview.Current.RequestReview(false);
            }
        }

        //Set value from data class to ViewModel properties
        public void StartExtractData(string htmlString)
        {
            #region Intersitial Ad
            
            adsCount++;

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-8211072909515345/8885441043");
                    break;
                case Device.iOS:
                    CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-8211072909515345/5805813104");
                    break;
            }

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

            FavoriteVehicle1 = data.Info().FavoriteVehicle1;
            FavoriteVehicle2 = data.Info().FavoriteVehicle2;
            FavoriteVehicle3 = data.Info().FavoriteVehicle3;
            FavoriteVehicle4 = data.Info().FavoriteVehicle4;
            FavoriteVehicle5 = data.Info().FavoriteVehicle5;

            FavoriteVehicleName1 = data.Info().FavoriteVehicleName1;
            FavoriteVehicleName2 = data.Info().FavoriteVehicleName2;
            FavoriteVehicleName3 = data.Info().FavoriteVehicleName3;
            FavoriteVehicleName4 = data.Info().FavoriteVehicleName4;
            FavoriteVehicleName5 = data.Info().FavoriteVehicleName5;

            FavoriteVehicleIcon1 = data.Info().FavoriteVehicleIcon1;
            FavoriteVehicleIcon2 = data.Info().FavoriteVehicleIcon2;
            FavoriteVehicleIcon3 = data.Info().FavoriteVehicleIcon3;
            FavoriteVehicleIcon4 = data.Info().FavoriteVehicleIcon4;
            FavoriteVehicleIcon5 = data.Info().FavoriteVehicleIcon5;

            DoughnutSeriesData.Clear();
            DoughnutSeriesData.Add(new ChartDataModel(AppResources.AirAB, data.Info().CountAAB));
            DoughnutSeriesData.Add(new ChartDataModel(AppResources.AirRB, data.Info().CountARB));
            DoughnutSeriesData.Add(new ChartDataModel(AppResources.AirSB, data.Info().CountASB));
            DoughnutSeriesData.Add(new ChartDataModel(AppResources.TankAB, data.Info().CountTAB));
            DoughnutSeriesData.Add(new ChartDataModel(AppResources.TankRB, data.Info().CountTRB));
            DoughnutSeriesData.Add(new ChartDataModel(AppResources.TankSB, data.Info().CountTSB));
            DoughnutSeriesData.Add(new ChartDataModel(AppResources.FleetAB, data.Info().CountSAB));
            DoughnutSeriesData.Add(new ChartDataModel(AppResources.FleetRB, data.Info().CountSRB));

            BarChartData.Clear();
            BarChartData.Add(new BarChartDataModel(AppResources.France, data.Info().ResearchedFrance));
            BarChartData.Add(new BarChartDataModel(AppResources.Italy, data.Info().ResearchedItaly));
            BarChartData.Add(new BarChartDataModel(AppResources.Japan, data.Info().ResearchedJapan));
            BarChartData.Add(new BarChartDataModel(AppResources.Britain, data.Info().ResearchedBritain));
            BarChartData.Add(new BarChartDataModel(AppResources.USSR, data.Info().ResearchedUSSR));
            BarChartData.Add(new BarChartDataModel(AppResources.Germany, data.Info().ResearchedGermany));
            BarChartData.Add(new BarChartDataModel(AppResources.USA, data.Info().ResearchedUSA));
        }
        #endregion
    }
}