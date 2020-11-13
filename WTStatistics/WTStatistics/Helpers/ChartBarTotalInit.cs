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
                new BarChartDataModel("", 300),
                new BarChartDataModel("", 300),
                new BarChartDataModel("", 300),
                new BarChartDataModel("", 300),
                new BarChartDataModel("", 300),
                new BarChartDataModel("", 300),
                new BarChartDataModel("", 300)
            };
            return collection;
        }
    }
}
