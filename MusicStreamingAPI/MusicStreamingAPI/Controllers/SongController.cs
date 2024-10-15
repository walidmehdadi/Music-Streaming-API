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
            var songs = MusicData.Artists.SelectMany(a => a.Albums).SelectMany(al => al.Songs).ToList();
            return Ok(songs);  // Return all songs
        }

        [HttpGet("{id}")]
        public ActionResult<Song> GetSong(int id)
        {
            var song = MusicData.Artists.SelectMany(a => a.Albums).SelectMany(al => al.Songs).FirstOrDefault(s => s.Id == id);
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }
    }
}
