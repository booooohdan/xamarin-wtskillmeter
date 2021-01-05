using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WTStatistics.Models;

namespace WTStatistics.Helpers
{
    public class ChartBarTotalInit
    {
        public static ObservableCollection<BarChartDataModel> Init()
        {
            var collection = new ObservableCollection<BarChartDataModel>
            {
                new BarChartDataModel("", 128),
                new BarChartDataModel("", 147),
                new BarChartDataModel("", 195),
                new BarChartDataModel("", 248),
                new BarChartDataModel("", 337),
                new BarChartDataModel("", 297),
                new BarChartDataModel("", 285)
            };
            return collection;
        }
    }
}
