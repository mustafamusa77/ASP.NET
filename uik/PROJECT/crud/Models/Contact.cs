using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public int? Marks { get; set; }
    }
}


