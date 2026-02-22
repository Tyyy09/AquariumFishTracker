namespace AquariumFishTracker.Models
{
    public class Tank
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public double VolumeLiters { get; set; }
        public double TemperatureC { get; set; }
        public double PH { get; set; }
        public double Ammonia { get; set; }
        public double Nitrite { get; set; }
        public double Nitrate { get; set; }

        public DateTime? LastCleanedDate { get; set; }

        // Relationship
        public List<Fish> Fish { get; set; } = new();
    }
}
