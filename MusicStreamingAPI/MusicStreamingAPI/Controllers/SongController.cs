using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStreamingAPI.Models;

namespace MusicStreamingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Song>> GetSongs()
        {
            return Ok(MusicData.Songs);  // Return all songs
        }

        [HttpGet("{id}")]
        public ActionResult<Song> GetSong(int id)
        {
            // Find the song by its ID
            var song = MusicData.Songs.FirstOrDefault(s => s.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            // Return song details
            return Ok(song);
        }

        [HttpPost]
        public ActionResult AddSong(Song song)
        {
            if (!MusicData.Albums.Any(a => a.Id == song.AlbumId))
            {
                return BadRequest("The specified AlbumId does not exist.");
            }

            if (MusicData.Songs.Any(s => s.Id == song.Id))
            {
                return BadRequest("Song with this ID already exists.");
            }

            MusicData.Songs.Add(song);
            return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song);
        }
    }
}
