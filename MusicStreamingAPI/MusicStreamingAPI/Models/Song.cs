using System.ComponentModel.DataAnnotations;

namespace MusicStreamingAPI.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The title must be between 1 and 20 characters long.")]
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
    }
}
