using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MotorLine.ViewModel
{
    public class AdVM
    {
           public int AdID { get; set; }
            [Required]
            [MaxLength(100,ErrorMessage ="Maximum Length of title's characters is 100")] // Limit title length to 100 characters

        [Remote("checkTitle",  null, ErrorMessage = "Title Already Exists")]
            public string Title { get; set; } = null!;

            [Required]
            public string Description { get; set; } = null!;

        [Required(ErrorMessage = "the Price field is required")]
        [Range(1, 1000000, ErrorMessage = "Price must be between 1 and 1,000,000.")]
        public decimal Price { get; set; } 

            [Required]
            public string Condition { get; set; } = null!;

            [Required]
            public string Category { get; set; } = null!;

            [Required]
            public string Model { get; set; } = null!;

        [Required(ErrorMessage = "the Year field is required")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2025.")]
        public int Year { get; set; } 

            [Required]
            public string Type { get; set; } = null!;

            [Required]
            public string FuelType { get; set; } = null!;

            [Required]
            public string Motor { get; set; } = null!;

            [Required]
            public string Color { get; set; } = null!;

            [Required(ErrorMessage = "You must add at least one photo")]

             [Display( Name ="First Picture")]
            public IFormFile Photo1 { get; set; } = null!;

            [Display(Name = "Second Picture")]
            public IFormFile? Photo2 { get; set; }

            [Display(Name = "Third Picture")]
            public IFormFile? Photo3 { get; set; }

            [Display(Name = " Fourth Picture")]
            public IFormFile? Photo4 { get; set; }

            [Display(Name = "Fifth Picture")]
            public IFormFile? Photo5 { get; set; }


        }
    }

