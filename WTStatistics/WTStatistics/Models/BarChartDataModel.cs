using System;
using System.Collections.Generic;
using System.Text;

namespace WTStatistics.Models
{
    public class BarChartDataModel
    {
        public string Country { get; set; }

        public double Count { get; set; }

        public BarChartDataModel(string xValue, double yValue)
        {
            Country = xValue;
            Count = yValue;
        }
    }
}
