using System;
using System.Collections.Generic;
using System.Text;

namespace WTStatistics.Models
{
    public class Preference
    {
        public string Name { get; set; }
        public double Count { get; set; }
        public string Icon { get; set; }

        public Preference(string Name, double Count, string Icon)
        {
            this.Name = Name;
            this.Count = Count;
            this.Icon = Icon;
        }

    }
}
