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
            var albums = MusicData.Artists.SelectMany(a => a.Albums).ToList();
            return Ok(albums);  // Return all albums
        }

        [HttpGet("{id}")]
        public ActionResult<Album> GetAlbum(int id)
        {
            var album = MusicData.Artists.SelectMany(a => a.Albums).FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }
    }
}
