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
    public class HintsViewModel:BaseViewModel
    {
        public ObservableCollection<ChartDataModel> DoughnutSeriesDataMock { get; set; }
        public ObservableCollection<BarChartDataModel> BarChartDataTotal { get; set; }
        public ObservableCollection<BarChartDataModel> BarChartDataMock { get; set; }

        public HintsViewModel()
        {
            DoughnutSeriesDataMock = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(AppResources.AirAB, 3540),
                new ChartDataModel(AppResources.AirRB, 19370),
                new ChartDataModel(AppResources.AirSB, 80),
                new ChartDataModel(AppResources.TankAB, 310),
                new ChartDataModel(AppResources.TankRB, 16500),
                new ChartDataModel(AppResources.TankSB, 510),
                new ChartDataModel(AppResources.FleetAB, 60),
                new ChartDataModel(AppResources.FleetRB, 530)
            };

            BarChartDataTotal = ChartBarTotalInit.Init();

            BarChartDataMock = new ObservableCollection<BarChartDataModel>
            {
                new BarChartDataModel(AppResources.France, 75),
                new BarChartDataModel(AppResources.Italy, 90),
                new BarChartDataModel(AppResources.Japan, 115),
                new BarChartDataModel(AppResources.Britain, 117),
                new BarChartDataModel(AppResources.USSR, 177),
                new BarChartDataModel(AppResources.Germany, 186),
                new BarChartDataModel(AppResources.USA, 153)
            };
        }
    }
}
