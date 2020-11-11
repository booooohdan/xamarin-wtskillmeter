using System.Collections.ObjectModel;
using WTStatistics.Models;
using WTStatistics.Resx;

namespace WTStatistics.Helpers
{
    public class DoughnutInit
    {
        public static ObservableCollection<ChartDataModel> Init()
        {
            var collection = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(AppResources.AirAB, 0),
                new ChartDataModel(AppResources.AirRB, 0),
                new ChartDataModel(AppResources.AirSB, 0),
                new ChartDataModel(AppResources.TankAB, 0),
                new ChartDataModel(AppResources.TankRB, 0),
                new ChartDataModel(AppResources.TankSB, 0),
                new ChartDataModel(AppResources.FleetAB, 0),
                new ChartDataModel(AppResources.FleetRB, 0)
            };
            return collection;
        }
    }
}