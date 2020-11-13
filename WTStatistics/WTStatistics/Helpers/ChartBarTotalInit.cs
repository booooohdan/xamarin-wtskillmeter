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
                new BarChartDataModel("", 125),
                new BarChartDataModel("", 141),
                new BarChartDataModel("", 192),
                new BarChartDataModel("", 242),
                new BarChartDataModel("", 329),
                new BarChartDataModel("", 297),
                new BarChartDataModel("", 282)
            };
            return collection;
        }
    }
}
