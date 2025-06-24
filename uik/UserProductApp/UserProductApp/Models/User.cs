using System.ComponentModel.DataAnnotations;

namespace UserProductApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
