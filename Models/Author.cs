using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WAD.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Biography { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
