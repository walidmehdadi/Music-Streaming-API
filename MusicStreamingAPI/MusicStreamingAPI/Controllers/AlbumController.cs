using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStreamingAPI.Models;

namespace MusicStreamingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Album>> GetAlbums()
        {
            return Ok(MusicData.Albums);  // Return all albums
        }

        [HttpGet("{id}")]
        public ActionResult<Album> GetAlbum(int id)
        {
            // Find the album by ID
            var album = MusicData.Albums.FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            // Return album details
            return Ok(album);
        }
    }
}
