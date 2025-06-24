using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}

