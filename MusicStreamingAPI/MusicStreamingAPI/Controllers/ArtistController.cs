using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStreamingAPI.Models;

namespace MusicStreamingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Artist>> GetArtists()
        {
            return Ok(MusicData.Artists);  // Return all artists
        }

        [HttpGet("{id}")]
        public ActionResult<Artist> GetArtist(int id)
        {
            // Find the artist by its ID
            var artist = MusicData.Artists.FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            // Return artist details
            return Ok(artist);
        }
    }
}
