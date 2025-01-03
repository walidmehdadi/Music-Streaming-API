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

        [HttpPost]
        public ActionResult AddAlbum(Album album)
        {
            if (!MusicData.Artists.Any(a => a.Id == album.ArtistId))
            {
                return BadRequest("The specified ArtistId does not exist.");
            }

            if (MusicData.Albums.Any(a => a.Id == album.Id))
            {
                return BadRequest("Album with this ID already exists.");
            }

            MusicData.Albums.Add(album);
            return CreatedAtAction(nameof(GetAlbum), new { id = album.Id }, album);
        }

        [HttpPut("{id}")]
        public ActionResult<Artist> UpdateAlbum(int id, Album updatedAlbum)
        {
            if (id != updatedAlbum.Id)
            {
                return BadRequest("The provided ids don't match.");
            }

            var album = MusicData.Albums.FirstOrDefault(x => x.Id == id);

            if (album == null)
            {
                return NotFound("The album doesn't exist.");
            }

            if (album != null)
            {
                album.Title = updatedAlbum.Title;
            }

            return Ok(album);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAlbum(int id)
        {
            var album = MusicData.Albums.FirstOrDefault(s => s.Id == id);

            if (album == null)
            {
                return NotFound();
            }

            MusicData.Albums.Remove(album);

            return NoContent();
        }
    }
}
