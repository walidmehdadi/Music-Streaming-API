namespace MusicStreamingAPI.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }
    }
}
