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
            return Ok(MusicData.Artists);  // Return the hardcoded list of artists
        }

        [HttpGet("{id}")]
        public ActionResult<Artist> GetArtist(int id)
        {
            var artist = MusicData.Artists.FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

    }
}
