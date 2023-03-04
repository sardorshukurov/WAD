using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WAD.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
