namespace Duffnization.Domain
{
    public class BearStyle
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }
        public int AverageTemperature { get; set; }
    }
}