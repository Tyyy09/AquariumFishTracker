namespace AquariumFishTracker.Models
{
    public class Fish
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public double LengthCm { get; set; }
        public double WeightGrams { get; set; }
        public DateTime DateAdded { get; set; }

        // Relationship
        public int? TankId { get; set; }
        public Tank? Tank { get; set; }
    }
}
