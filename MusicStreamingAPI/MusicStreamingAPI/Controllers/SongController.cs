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
    }
}
