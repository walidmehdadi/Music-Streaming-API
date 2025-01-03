using System.ComponentModel.DataAnnotations;

namespace MusicStreamingAPI.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The name must be between 1 and 100 characters long.")]
        public string Name { get; set; }
    }
}
