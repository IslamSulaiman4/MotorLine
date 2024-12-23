namespace MotorLine.Models
{
	public class Ad
	{
		public int AdID { get; set; }
		public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public string Condition { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
		public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
		public string FuelType { get; set; } = null!;
        public string Motor { get; set; } = null!;
        public string Color { get; set; } = null!;

        public string Photo1 { get; set; } = null!;
        public string? Photo2 { get; set; }
        public string? Photo3 { get; set; }
        public string? Photo4 { get; set; }
        public string? Photo5 { get; set; }

    }
}
