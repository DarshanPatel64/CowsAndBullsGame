using System.ComponentModel.DataAnnotations;

namespace Cow_and_Bulls_game.Models
{
    public class User
    {
        [Required]
        [Display(Name ="Enter Username")]
        public string UserId { get; set; } 
        [Required]
        [Display(Name = "Enter password")]
        public string Password { get; set; }
    }
}
