using MusicStreamingAPI.Models;

namespace MusicStreamingAPI
{
    public static class MusicData
    {
        public static List<Artist> Artists = new List<Artist>
        {
            new Artist { Id = 1, Name = "The Beatles" },
            new Artist { Id = 2, Name = "Queen" }
        };

        public static List<Album> Albums = new List<Album>
        {
            new Album { Id = 1, Title = "Abbey Road", ArtistId = 1 },
            new Album { Id = 2, Title = "Sgt. Pepper's Lonely Hearts Club Band", ArtistId = 1 },
            new Album { Id = 3, Title = "A Night at the Opera", ArtistId = 2 }
        };

        public static List<Song> Songs = new List<Song>
        {
            new Song { Id = 1, Title = "Come Together", AlbumId = 1 },
            new Song { Id = 2, Title = "Something", AlbumId = 1 },
            new Song { Id = 3, Title = "Lucy in the Sky with Diamonds", AlbumId = 2 },
            new Song { Id = 4, Title = "A Day in the Life", AlbumId = 2 },
            new Song { Id = 5, Title = "Bohemian Rhapsody", AlbumId = 3 },
            new Song { Id = 6, Title = "You're My Best Friend", AlbumId = 3 }
        };

    }
}
