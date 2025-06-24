using System.ComponentModel.DataAnnotations;

namespace Testing.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Phone { get; set; }
    }
}
