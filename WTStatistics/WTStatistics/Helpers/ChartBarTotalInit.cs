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
                new BarChartDataModel("", 134), //France
                new BarChartDataModel("", 155), //Italy
                new BarChartDataModel("", 206), //Japan
                new BarChartDataModel("", 269), //Britain
                new BarChartDataModel("", 348), //USSR
                new BarChartDataModel("", 317), //Germany
                new BarChartDataModel("", 303)  //USA
                //WT_WIKI_test
            };
            return collection;
        }
    }
}
