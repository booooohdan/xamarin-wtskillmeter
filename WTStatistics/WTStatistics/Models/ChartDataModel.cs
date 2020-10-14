namespace WTStatistics.Models
{
    public class ChartDataModel
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public ChartDataModel(string Name, int Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
    }
}