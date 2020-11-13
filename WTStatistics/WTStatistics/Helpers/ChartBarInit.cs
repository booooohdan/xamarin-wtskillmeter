using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WTStatistics.Models;

namespace WTStatistics.Helpers
{
    public class ChartBarInit
    {
        public static ObservableCollection<BarChartDataModel> Init()
        {
            var collection = new ObservableCollection<BarChartDataModel>
            {
                new BarChartDataModel(Resx.AppResources.France, 0),
                new BarChartDataModel(Resx.AppResources.Italy, 0),
                new BarChartDataModel(Resx.AppResources.Japan, 0),
                new BarChartDataModel(Resx.AppResources.Britain, 0),
                new BarChartDataModel(Resx.AppResources.USSR, 0),
                new BarChartDataModel(Resx.AppResources.Germany, 0),
                new BarChartDataModel(Resx.AppResources.USA, 0)
            };
            return collection;
        }
    }
}
