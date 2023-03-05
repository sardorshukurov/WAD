using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WAD.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string Biography { get; set; }
    }
}
