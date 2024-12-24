using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MotorLine.Models
{
    [Index(nameof(Title),IsUnique=true)]
    public class Ad
    {
        public int AdID { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; } 

        [Required]
        public string Condition { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;

        [Required]
        public int Year { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public string FuelType { get; set; } = null!;

        [Required]
        public string Motor { get; set; } = null!;

        [Required]
        public string Color { get; set; } = null!;

        [Required] 
        public string Photo1 { get; set; } = null!;

        public string? Photo2 { get; set; }
        public string? Photo3 { get; set; }
        public string? Photo4 { get; set; }
        public string? Photo5 { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
