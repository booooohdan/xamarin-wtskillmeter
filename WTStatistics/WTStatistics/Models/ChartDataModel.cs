namespace WTStatistics.Models
{
    public class ChartDataModel
    {
        public string Name;
        public int Value;

        public ChartDataModel(string Name, int Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
    }
}