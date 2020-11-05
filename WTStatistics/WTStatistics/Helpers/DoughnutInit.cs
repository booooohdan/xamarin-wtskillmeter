using System.Collections.ObjectModel;
using WTStatistics.Models;

namespace WTStatistics.Helpers
{
    public class DoughnutInit
    {
        public static ObservableCollection<ChartDataModel> Init()
        {
            var collection = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Air AB", 0),
                new ChartDataModel("Air RB", 0),
                new ChartDataModel("Air SB", 0),
                new ChartDataModel("Tank AB", 0),
                new ChartDataModel("Tank RB", 0),
                new ChartDataModel("Tank SB", 0),
                new ChartDataModel("Fleet AB", 0),
                new ChartDataModel("Fleet RB", 0)
            };
            return collection;
        }
    }
}