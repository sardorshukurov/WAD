using System;
using System.ComponentModel.DataAnnotations;

namespace WAD.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        [MinLength(5), MaxLength(100)]
        public string Title { get; set; }

        public Author Author { get; set; }

        [Required(ErrorMessage = "Please enter a publisher")]
        [MinLength(5), MaxLength(100)]
        public string Publisher { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "Please enter an ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Please enter a price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        public Category Category { get; set; }

        public string Image { get; set; }

        [Range(0, 5, ErrorMessage = "Please enter a rating between 0 and 5")]
        public double Rating { get; set; }
    }
}
